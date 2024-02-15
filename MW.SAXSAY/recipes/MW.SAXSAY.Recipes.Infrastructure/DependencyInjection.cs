using Microsoft.Extensions.DependencyInjection;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;
using recipes.MW.SAXSAY.Recipes.Infraestructure.Persistence.SqlServer.Repositories;
using recipes.MW.SAXSAY.Recipes.Infrastructure.Persistence.SqlServer.Context;

namespace recipes.MW.SAXSAY.Recipes.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructureLayer(this IServiceCollection services)
    {
        services.AddServices();
        return services;
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ApplicationDbContext>();

        services
            .AddScoped<IUnitOfWork, SqlUnitOfWork>()
            .AddScoped<IRecipeRepository, RecipeRepository>()
            .AddScoped<IIngredientRepository, IngredientRepository>();
    }
}