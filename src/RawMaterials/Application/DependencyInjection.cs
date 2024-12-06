using Microsoft.Extensions.DependencyInjection;

namespace MW.SAXSAY.RawMaterials.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        var applicationAssembly = typeof(DependencyInjection).Assembly;

        services
            .AddAutoMapper(applicationAssembly)
            .AddMediatR(
            config => config.RegisterServicesFromAssemblies(applicationAssembly));

        return services;
    }
}