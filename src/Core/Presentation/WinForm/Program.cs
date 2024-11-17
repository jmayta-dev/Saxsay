using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MW.SAXSAY.RawMaterials.Presentation.WinForm;

namespace MW.SAXSAY.Core.Presentation.WinForm;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        IHost host = Host
            .CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services
                    .AddCoreServices()          // MW.SAXSAY.Core
                    .AddRawMaterialServices();  // MW.SAXSAY.RawMaterials
            })
            .Build();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // get login form
        var startupForm = host.Services.GetRequiredService<frmLogin>();
        // execute login form as entrypoint
        System.Windows.Forms.Application.Run(startupForm);
    }
}