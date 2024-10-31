using AutoMapper;
using MediatR;
using MW.SAXSAY.RawMaterials.Application.DTOs;
using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;
using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetRawMaterialsByFilter;
using MW.SAXSAY.Shared.Extensions;
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
    private readonly BindingList<GetRawMaterialDTO> _rawMaterials = [];
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
        throw new NotImplementedException();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
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

    private  void tsmiSave_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private  void txtTextToSearch_KeyPress(object sender, KeyPressEventArgs e)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Adds raw material empty row in data grid
    /// </summary>
    private void AddRawMaterial()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Bind data to data grid
    /// </summary>
    private void BindDataGridView()
    {
        dgvRawMaterials.DataSource = _rawMaterials;
    }

    /// <summary>
    /// Filter raw materials by description
    /// </summary>
    /// <returns></returns>
    private Task FilterRawMaterials()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
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
    /// Retrieve Raw Materials
    /// </summary>
    /// <param name="queryText"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    private Task<IEnumerable<GetRawMaterialDTO>> GetRawMaterials(
        string queryText, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    private void InitializeControls()
    {
        BindDataGridView();
    }

    private void LoadControls()
    {
        ConfigDataGridBehaviors();
        InitializeControls();
    }
    #endregion
}