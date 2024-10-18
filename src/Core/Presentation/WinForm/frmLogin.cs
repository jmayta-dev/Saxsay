using Microsoft.Extensions.DependencyInjection;
using MW.SAXSAY.Core.Presentation.WinForm.Enumerators;

namespace MW.SAXSAY.Core.Presentation.WinForm;

public partial class frmLogin : Form
{
    #region Properties & Variables
    private SaxsayCloseReason _closeReason = SaxsayCloseReason.None;
    private readonly IServiceProvider _services;
    #endregion

    #region Constructor
    /// <summary>
    /// Create an instance of <see cref="frmLogin"/>
    /// </summary>
    public frmLogin()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Create an instance of <see cref="frmLogin"/>
    /// </summary>
    /// <param name="services"></param>
    public frmLogin(IServiceProvider services) : this()
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        _services = services;
    }

    #endregion

    #region Events
    private void btnExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (new[] { txtUser.Text, txtPassword.Text }
            .Any(s => string.IsNullOrWhiteSpace(s)))
        {
            MessageBox.Show(
                "Porfavor, ingrese su usuario y contraseña.",
                "Inicio Sesión:",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation
            );
            return;
        }

        try
        {
            if (!LoginUser(txtUser.Text.Trim(), txtPassword.Text.Trim()))
            {
                MessageBox.Show(
                    text: string.Concat(
                        "Credenciales incorrectas. Por favor, verifique su nombre de ",
                        "usuario y/o contraseña."),
                    caption: "Inicio de Sesión:",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
        }
        catch (Exception)
        {
            throw;
        }

        this.ShowInTaskbar = false;
        OpenMdiMainForm();
    }

    private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }

    private void frmLogin_Load(object sender, EventArgs e)
    {
        // TODO: delete the following lines
        txtUser.Text = "administrador";
        txtPassword.Text = "administrador";
    }

    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == Convert.ToChar(Keys.Enter))
            btnLogin.PerformClick();
    }
    #endregion

    #region Methods
    private void ClearControls()
    {
        txtUser.Text = string.Empty;
        txtPassword.Text = string.Empty;
    }

    /// <summary>
    /// Open the MDI main form
    /// </summary>
    private void OpenMdiMainForm()
    {
        this.Hide();

        var _mainMDIForm = _services.GetRequiredService<frmMdiSaxsay>();
        _mainMDIForm.SaxsayCloseReason = _closeReason;
        _mainMDIForm.ShowDialog();

        switch (_mainMDIForm.SaxsayCloseReason)
        {
            case SaxsayCloseReason.Logout:
                _closeReason = SaxsayCloseReason.None;
                ClearControls();
                this.ShowInTaskbar = true;
                break;
            case SaxsayCloseReason.ApplicationExit:
                _closeReason = SaxsayCloseReason.ApplicationExit;
                this.Close();
                break;
            case SaxsayCloseReason.None:
            default:
                break;
        }
    }

    private bool LoginUser(string user, string password)
    {
        // TODO: implement sign in logic
        // UseCase: LoginWithCredentials(user, pass)
        return true;
    }
    #endregion
}
