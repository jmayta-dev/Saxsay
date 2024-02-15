using Microsoft.Extensions.DependencyInjection;

namespace recipes.MW.SAXSAY.Recipes.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        var applicationAssembly = typeof(DependecyInjection).Assembly;

        services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));
        services.AddAutoMapper(applicationAssembly);

        return services;
    }
}