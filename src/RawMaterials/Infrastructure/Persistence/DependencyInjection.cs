using Microsoft.Extensions.DependencyInjection;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.RawMaterials.Persistence.SQLServer.Context;
using MW.SAXSAY.RawMaterials.Persistence.SQLServer.Repositories;

namespace MW.SAXSAY.RawMaterials.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
    {
        return services
            .AddSingleton<RawMaterialDbContext>()
            .AddTransient<IUnitOfWorkRawMaterial, UnitOfWorkRawMaterial>();
    }
}