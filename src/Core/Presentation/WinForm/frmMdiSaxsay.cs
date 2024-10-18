using Microsoft.Extensions.DependencyInjection;
using MW.SAXSAY.Core.Presentation.WinForm.Enumerators;
using MW.SAXSAY.Core.Presentation.WinForm.Properties;

namespace MW.SAXSAY.Core.Presentation.WinForm;

public partial class frmMdiSaxsay : Form
{
    #region Properties & Variables
    //
    // private
    //
    private SaxsayCloseReason _closeReason;
    private Dictionary<string, string> _menuForms = [];
    private TreeNodeCollection _menuOptions;
    private bool _menuShowed = true;
    private readonly IServiceProvider _services;
    //
    // public
    //
    internal SaxsayCloseReason SaxsayCloseReason
    {
        get => _closeReason;
        set => _closeReason = value;
    }
    #endregion

    #region Constructor
    /// <summary>
    /// Create an instance of <see cref="frmMdiSaxsay"/>
    /// </summary>
    public frmMdiSaxsay()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Create an instance of <see cref="frmMdiSaxsay"/>
    /// </summary>
    /// <param name="services"></param>
    public frmMdiSaxsay(IServiceProvider services) : this()
    {
        _services = services;
    }
    #endregion

    #region Events
    private void frmMdiSaxsay_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            var result = MessageBox.Show(
                "¿Realmente desea salir de la aplicación?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;
            else
                _closeReason = SaxsayCloseReason.ApplicationExit;
        }
    }
    private void frmMdiSaxsay_Load(object sender, EventArgs e)
    {
        LoadMenu();
    }

    private void tsbtnShowHide_Click(object sender, EventArgs e)
    {
        _menuShowed = !_menuShowed;
        tlpSidebar.Visible = _menuShowed;
        tsbtnShowHide.Image = _menuShowed ? Resources.TableFillLeft : Resources.TableFillRight;
    }

    private void tsmiLogout_Click(object sender, EventArgs e)
    {
        try
        {
            if (!LogoutUser())
            {
                MessageBox.Show(
                   "Ocurrió un problema al intentar cerrar la sesión.",
                   "Cerrar Sesión:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Close();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void tvwMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Methods
    private void LoadMenu()
    {
        // TODO: Implement the menu load logic
    }

    /// <summary>
    /// Log out the user
    /// </summary>
    /// <returns>True if the user was logged out successfully</returns>
    private bool LogoutUser()
    {
        // TODO: implement logic for sign out user
        _closeReason = SaxsayCloseReason.Logout;
        return true;
    }
    #endregion
}
