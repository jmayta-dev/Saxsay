﻿using AutoMapper;
using MediatR;
using MW.SAXSAY.RawMaterials.Application.DTO;
using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;
using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetRawMaterialsByFilter;
using MW.SAXSAY.Shared.Helpers;
using System.ComponentModel;

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
        if (dgvRawMaterials.SelectedRows.Count > 0 &&
            dgvRawMaterials.SelectedRows[0].Index >= 0)
        {
            var dialogResult = MessageBox.Show(
                "Deshabilitar Materias Prima:",
                "¿Está seguro de deshabilitar la(s) Materia(s) Prima seleccionada(s)?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No) return;

            List<GetRawMaterialDTO> rawMaterialsSelected = [];
            foreach (DataGridViewRow row in dgvRawMaterials.SelectedRows)
            {
                if (row.DataBoundItem is GetRawMaterialDTO rawMaterial)
                {
                    rawMaterial.IsEnabled = false;
                    rawMaterialsSelected.Add(rawMaterial);
                }
            }

            dgvRawMaterials.Refresh();
        }
        else
        {
            MessageBox.Show(
                "Deshabilitar Materia(s) Prima:",
                "Primero debe seleccionar al menos un elemento para deshabilitar.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnEnable_Click(object sender, EventArgs e)
    {
        if (dgvRawMaterials.SelectedRows.Count > 0 &&
           dgvRawMaterials.SelectedRows[0].Index >= 0)
        {
            var dialogResult = MessageBox.Show(
                "Deshabilitar Materias Prima:",
                "¿Está seguro de habilitar la(s) Materia(s) Prima seleccionada(s)?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No) return;

            List<GetRawMaterialDTO> rawMaterialsSelected = [];
            foreach (DataGridViewRow row in dgvRawMaterials.SelectedRows)
            {
                if (row.DataBoundItem is GetRawMaterialDTO rawMaterial)
                {
                    rawMaterial.IsEnabled = true;
                    rawMaterialsSelected.Add(rawMaterial);
                }
            }

            dgvRawMaterials.Refresh();
        }
        else
        {
            MessageBox.Show(
                "Habilitar Materia(s) Prima:",
                "Primero debe seleccionar al menos un elemento para habilitar.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        if (dgvRawMaterials.SelectedRows.Count > 0 &&
             dgvRawMaterials.SelectedRows[0].Index >= 0)
        {
            var dialogResult = MessageBox.Show(
               "Eliminar Materia(s) Prima:",
               "¿Está seguro de eliminar la(s) Materia(s) Prima seleccionada(s)?",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No) return;

            // TODO: implemnt a validation to avoid removing raw materials that are in use
            foreach (DataGridViewRow row in dgvRawMaterials.SelectedRows)
            {
                if (row.DataBoundItem is GetRawMaterialDTO rawMaterial)
                { _rawMaterials.Remove(rawMaterial); }
            }

            dgvRawMaterials.Refresh();
        }
        else
        {
            MessageBox.Show(
                "Eliminar Materia(s) Prima:",
                "Primero debe seleccionar al menos un elemento para eliminar.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            await SearchRawMaterials();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private async Task SearchRawMaterials()
    {
        var rawMaterials = await GetRawMaterials();
        BindRawMaterialsDataGridView(rawMaterials);
    }

    private void dgvRawMaterials_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
            AddRawMaterial();
    }

    private void frmRawMaterialManagement_Load(object sender, EventArgs e)
    {
        try
        {
            LoadControls();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void tsmiClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void tsmiSave_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private async void txtTextToSearch_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar != (char)Keys.Enter) return;
        try
        {
            await SearchRawMaterials();
        }
        catch (Exception ex)
        {

            throw;
        }
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
                "Obtener Materias Prima:",
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
              "Buscar Materias Prima:",
              "Ocurrió un error al buscar Materias Prima.",
              "Buscar Materias Prima:",
              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return [];
        }

        return queryResult.Value;
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

    /// <summary>
    /// Bind the search result into data grid view
    /// </summary>
    /// <returns></returns>
    private async Task SearchRawMaterials()
    {
        _rawMaterials.Clear();
        _rawMaterialsForInsert.Clear();
        _rawMaterialsForUpdate.Clear();
        _rawMaterialsForDelete.Clear();

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