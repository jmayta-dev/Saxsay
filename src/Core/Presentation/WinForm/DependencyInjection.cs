using Microsoft.Extensions.DependencyInjection;
using MW.SAXSAY.Core.Application;

namespace MW.SAXSAY.Core.Presentation.WinForm
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            return services
                .AddApplicationLayer()
                .AddPresentationLayer();
        }

        private static IServiceCollection AddPresentationLayer(this IServiceCollection services)
        {
            return services
                .AddSingleton<frmMdiSaxsay>();
        }
        }
    }
