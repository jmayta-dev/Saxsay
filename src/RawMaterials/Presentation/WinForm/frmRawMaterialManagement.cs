using AutoMapper;
using MediatR;
using MW.SAXSAY.RawMaterials.Application.DTO;
using MW.SAXSAY.RawMaterials.Application.UseCases.Commands.RegisterRawMaterials;
using MW.SAXSAY.RawMaterials.Application.UseCases.Commands.RemoveRawMaterials;
using MW.SAXSAY.RawMaterials.Application.UseCases.Commands.UpdateRawMaterials;
using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;
using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetRawMaterialsByFilter;
using MW.SAXSAY.Shared.Extensions;
using MW.SAXSAY.Shared.Helpers;
using System.ComponentModel;
using System.Text;

namespace MW.SAXSAY.RawMaterials.Presentation.WinForm;

public partial class frmRawMaterialManagement : Form
{
    #region Properties & Variables
    //
    // dependencies
    //
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    //
    // privates
    //
    private readonly BindingList<RawMaterialDTO> _rawMaterials = [];
    private readonly List<DeleteRawMaterialDTO> _rawMaterialsForDelete = [];
    private readonly List<RawMaterialDTO> _rawMaterialsForInsert = [];
    private readonly List<RawMaterialDTO> _rawMaterialsForUpdate = [];
    //
    // publics
    //
    #endregion

    #region Constructor
    /// <summary>
    /// Create an instance of <see cref="frmRawMaterialManagement"/>
    /// </summary>
    public frmRawMaterialManagement()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Create an instance of <see cref="frmRawMaterialManagement"/>
    /// </summary>
    /// <param name="sender">MediatR sender</param>
    /// <param name="mapper">Automapper mapper</param>
    public frmRawMaterialManagement(ISender sender, IMapper mapper) : this()
    {
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
    }
    #endregion

    #region Events
    private void btnAdd_Click(object sender, EventArgs e)
    {
        AddRawMaterial();
    }

    private void btnDisable_Click(object sender, EventArgs e)
    {
        if (dgvRawMaterials.SelectedRows.Count > 0)
        {
            var dialogResult = MessageBox.Show(
                "¿Está seguro de deshabilitar la(s) Materia(s) Prima seleccionada(s)?",
                "Deshabilitar Materias Prima:",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No) return;

            var selectedRawMaterials = GetSelectedRows().ToList();
            // disabling
            EnableOrDisableRawMaterials(selectedRawMaterials, enable: false);
            dgvRawMaterials.Refresh();
        }
        else
        {
            MessageBox.Show(
                "Primero debe seleccionar al menos un elemento para deshabilitar.",
                "Deshabilitar Materia(s) Prima:",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnEnable_Click(object sender, EventArgs e)
    {
        if (dgvRawMaterials.SelectedRows.Count > 0)
        {
            var dialogResult = MessageBox.Show(
                "¿Está seguro de habilitar la(s) Materia(s) Prima seleccionada(s)?",
                "Deshabilitar Materias Prima:",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No) return;

            var selectedRawMaterials = GetSelectedRows().ToList();
            // enabling
            EnableOrDisableRawMaterials(selectedRawMaterials, enable: true);
            dgvRawMaterials.Refresh();
        }
        else
        {
            MessageBox.Show(
                "Primero debe seleccionar al menos un elemento para habilitar.",
                "Habilitar Materia(s) Prima:",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        if (dgvRawMaterials.SelectedRows.Count > 0)
        {
            var dialogResult = MessageBox.Show(
               "¿Está seguro de eliminar la(s) Materia(s) Prima seleccionada(s)?",
               "Eliminar Materia(s) Prima:",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No) return;

            List<RawMaterialDTO> selectedRawMaterials = GetSelectedRows().ToList();

            // TODO: implemnt a validation to avoid removing raw materials that are in use
            foreach (var rawMaterial in selectedRawMaterials)
            {
                _rawMaterials.Remove(rawMaterial);

                // raw material caching management
                if (rawMaterial.CreatedAt == null)
                { _rawMaterialsForInsert.RemoveAll(r => r.Id == rawMaterial.Id); }
                else
                {
                    // ensure remove from updating list
                    _rawMaterialsForUpdate.RemoveAll(r => r.Id == rawMaterial.Id);
                    _rawMaterialsForDelete.Add(_mapper.Map<DeleteRawMaterialDTO>(rawMaterial));
                }
            }

            dgvRawMaterials.Refresh();
        }
        else
        {
            MessageBox.Show(
                "Primero debe seleccionar al menos un elemento para eliminar.",
                "Eliminar Materia(s) Prima:",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        await SearchRawMaterials();
    }

    private void dgvRawMaterials_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            var selectedRawMaterial = dgvRawMaterials.CurrentRow.DataBoundItem as RawMaterialDTO;
            if (selectedRawMaterial == null) return;

            // raw material caching management
            if (selectedRawMaterial.CreatedAt != null &&
                !_rawMaterialsForUpdate.Exists(r => r.Id == selectedRawMaterial.Id))
            {
                _rawMaterialsForUpdate.Add(selectedRawMaterial);
            }
        }
    }

    private void dgvRawMaterials_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dgvRawMaterials.IsCurrentCellDirty)
        { dgvRawMaterials.CommitEdit(DataGridViewDataErrorContexts.Commit); }
    }

    private void dgvRawMaterials_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
            AddRawMaterial();
    }

    private void frmRawMaterialManagement_Load(object sender, EventArgs e)
    {
        LoadControls();
    }

    private void tsmiClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void tsmiHistory_Click(object sender, EventArgs e)
    {
        StringBuilder changeLog = new();
        foreach (var rawMaterial in _rawMaterialsForInsert)
        {
            changeLog.AppendLine($"- {rawMaterial.Id} : {rawMaterial.Name} (insertar)");
        }
        foreach (var rawMaterial in _rawMaterialsForUpdate)
        {
            changeLog.AppendLine($"- {rawMaterial.Id} : {rawMaterial.Name} (actualizar)");
        }
        foreach (var rawMaterial in _rawMaterialsForDelete)
        {
            changeLog.AppendLine($"- {rawMaterial.Id} : {rawMaterial.Name} (eliminar)");
        }
        MessageBox.Show(changeLog.ToString(), "Change Log:");
    }

    private async void tsmiSave_Click(object sender, EventArgs e)
    {
        await SaveChanges();
    }

    private async void txtTextToSearch_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar != (char)Keys.Enter) return;
        await SearchRawMaterials();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Adds raw material empty row in data grid
    /// </summary>
    private void AddRawMaterial()
    {
        var newRawMaterial = new RawMaterialDTO
        {
            Id = IdentifierGenerators.TimePlusRandomGenerator.Generate(),
            Name = string.Empty,
            UNSPSC = string.Empty,
            UNSPSCDescription = string.Empty,
            IsEnabled = true
        };
        _rawMaterials.Add(newRawMaterial);

        // add new raw material to insertion list
        if (!_rawMaterialsForInsert.Exists(r => r.Id == newRawMaterial.Id))
        {
            _rawMaterialsForInsert.Add(newRawMaterial);
        }

        dgvRawMaterials.CurrentCell = dgvRawMaterials
            .Rows[new Index(1, true)]
            .Cells[colName.Index];
        dgvRawMaterials.BeginEdit(true);
    }

    /// <summary>
    /// Bind data to data grid
    /// </summary>
    private void BindRawMaterialsDataGridView(IEnumerable<RawMaterialDTO> rawMaterials)
    {
        dgvRawMaterials.DataSource = rawMaterials;
    }

    /// <summary>
    /// Clear form controls
    /// </summary>
    private void ClearControls()
    {
        _rawMaterials.Clear();

        dgvRawMaterials.DataSource = null;
        txtTextToSearch.Text = string.Empty;
    }

    /// <summary>
    /// Configure data grid behaviors
    /// </summary>
    private void ConfigDataGridBehaviors()
    {
        dgvRawMaterials.AutoGenerateColumns = false;

        colId.DataPropertyName = "Id";
        colName.DataPropertyName = "Name";
        colUNSPSC.DataPropertyName = "UNSPSC";
        colUNSPSCDescription.DataPropertyName = "UNSPSCDescription";
        colCreatedAt.DataPropertyName = "CreatedAt";
        colUpdatedAt.DataPropertyName = "UpdatedAt";
        colIsEnabled.DataPropertyName = "IsEnabled";
    }

    /// <summary>
    /// Enable or disable raw materials selected in the data grid view
    /// </summary>
    private void EnableOrDisableRawMaterials(
        IEnumerable<RawMaterialDTO> rawMaterialsDto, bool enable = true)
    {
        foreach (var rawMaterial in rawMaterialsDto)
        {
            rawMaterial.IsEnabled = enable;
            // add raw materials which has creation date and doesn't exists in
            // the list to update
            if (rawMaterial.CreatedAt != null &&
                !_rawMaterialsForUpdate.Exists(r => r.Id == rawMaterial.Id))
            {
                _rawMaterialsForUpdate.Add(rawMaterial);
            }
        }
    }

    /// <summary>
    /// Get all Raw Materials (without filter)
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task<IEnumerable<GetRawMaterialDTO>> GetAllRawMaterials(
        CancellationToken cancellationToken = default)
    {
        var queryResult = await _sender
           .Send(new GetAllRawMaterialsQuery(), cancellationToken);

        if (queryResult.IsFailure || queryResult.Value == null)
        {
            MessageBox.Show(
                "Ocurrió un error al obtener lista de Materias Prima.",
                "Obtener Materias Prima:",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return [];
        }
        return queryResult.Value;
    }

    /// <summary>
    /// Get raw materials
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task<IEnumerable<GetRawMaterialDTO>> GetRawMaterials(
        CancellationToken cancellationToken = default)
    {
        string queryString = txtTextToSearch.Text.Trim();
        if (string.IsNullOrWhiteSpace(queryString))
        { return await GetAllRawMaterials(cancellationToken); }
        else
        { return await GetRawMaterialsByFilter(queryString, cancellationToken); }
    }

    /// <summary>
    /// Get raw materials by filter
    /// </summary>
    /// <param name="queryString"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task<IEnumerable<GetRawMaterialDTO>> GetRawMaterialsByFilter(
        string queryString, CancellationToken cancellationToken = default)
    {
        var queryResult = await _sender.Send(
            new GetRawMaterialsByFilterQuery(queryString),
            cancellationToken);

        if (queryResult.IsFailure || queryResult.Value == null)
        {
            MessageBox.Show(
              "Ocurrió un error al buscar Materias Prima.",
              "Buscar Materias Prima:",
              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return [];
        }

        return queryResult.Value;
    }

    /// <summary>
    /// Get data grid view selected rows
    /// </summary>
    /// <returns></returns>
    private IEnumerable<RawMaterialDTO> GetSelectedRows()
    {
        if (dgvRawMaterials.SelectedRows.Count <= 0) yield break;

        foreach (DataGridViewRow row in dgvRawMaterials.SelectedRows)
        {
            if (row.DataBoundItem is RawMaterialDTO rawMaterialDto)
            { yield return rawMaterialDto; }
        }
    }

    /// <summary>
    /// Initialize form controls
    /// </summary>
    private void InitializeControls()
    {
        BindRawMaterialsDataGridView(_rawMaterials);
    }

    /// <summary>
    /// Load form controls
    /// </summary>
    private void LoadControls()
    {
        ConfigDataGridBehaviors();
        InitializeControls();
    }

    private async Task SaveChanges(CancellationToken cancellationToken = default)
    {
        // collect lists
        var rawMaterialsForInsert = _rawMaterialsForInsert.Select(_mapper.Map<RegisterRawMaterialDTO>);
        var rawMaterialsForUpdate = _rawMaterialsForUpdate.Select(_mapper.Map<UpdateRawMaterialDTO>);
        var rawMaterialsForDelete = _rawMaterialsForDelete.Select(_mapper.Map<DeleteRawMaterialDTO>);

        var insertionTask = _sender.Send(new RegisterRawMaterialCommand(rawMaterialsForInsert), cancellationToken);
        var updatingTask = _sender.Send(new UpdateRawMaterialCommand(rawMaterialsForUpdate), cancellationToken);
        var deletionTask = _sender.Send(new RemoveRawMaterialsCommand(rawMaterialsForDelete), cancellationToken);

        var results = await Task.WhenAll(insertionTask, updatingTask, deletionTask);

        if (results.Any(r => r.IsFailure))
        {
            MessageBox.Show(
                "Ocurrió un problema al grabar los cambios.",
                "Grabar Cambios:",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        MessageBox.Show(
            "Cambios grabados correctamente.",
            "Grabar Cambios:",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        await SearchRawMaterials();
    }

    /// <summary>
    /// Bind the search result into data grid view
    /// </summary>
    /// <returns></returns>
    private async Task SearchRawMaterials()
    {
        _rawMaterials.Clear();
        _rawMaterialsForInsert.Clear();

        List<GetRawMaterialDTO> retrievedRawMaterials =
            (await GetRawMaterials()).ToList();

        // map from GetRawMaterialDTO to RawMaterialDTO for displaying
        List<RawMaterialDTO> rawMaterials = retrievedRawMaterials
            .Select(_mapper.Map<RawMaterialDTO>).ToList();

        _rawMaterials.AddRange(rawMaterials);
        BindRawMaterialsDataGridView(_rawMaterials);
    }
    #endregion
}