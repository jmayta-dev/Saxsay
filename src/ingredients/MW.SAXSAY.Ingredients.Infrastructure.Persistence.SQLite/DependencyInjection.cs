using Microsoft.Extensions.DependencyInjection;
using MW.SAXSAY.RawMaterials.Domain.Interfaces;
using MW.SAXSAY.RawMaterials.Infrastructure.Persistence.SQLite.Context;
using MW.SAXSAY.RawMaterials.Infrastructure.Persistence.SQLite.Resitories;

namespace MW.SAXSAY.RawMaterials.Infrastructure.Persistence.SQLite;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
    {
        services.AddServices();
        return services;
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IngredientDbContext>();
        services.AddTransient<IUnitOfWorkIngredient, UnitOfWorkIngredient>();
    }
}