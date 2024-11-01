using Microsoft.Extensions.DependencyInjection;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.RawMaterials.Persistence.SQLServer.Context;
using MW.SAXSAY.RawMaterials.Persistence.SQLServer.Repositories;

namespace MW.SAXSAY.RawMaterials.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
    {
        services.AddServices();
        return services;
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<RawMaterialDbContext>();
        services.AddTransient<IUnitOfWorkRawMaterial, UnitOfWorkRawMaterial>();
    }
}