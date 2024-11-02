using Microsoft.Extensions.DependencyInjection;
using MW.SAXSAY.RawMaterials.Application;
using MW.SAXSAY.RawMaterials.Persistence;

namespace MW.SAXSAY.RawMaterials.Presentation.WinForm
{
    public static class DependencyInjection
    {
        #region Methods
        //
        // public
        //
        public static IServiceCollection AddRawMaterialServices(this IServiceCollection services)
        {
            return services
                .AddApplicationLayer()
                .AddPersistenceLayer()
                .AddPresentationLayer();
        }

        //
        // private
        //

        /// <summary>
        /// Add forms to the service collection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddPresentationLayer(this IServiceCollection services)
        {
            return services.AddSingleton<frmRawMaterialManagement>();
        }
        #endregion
    }
}
