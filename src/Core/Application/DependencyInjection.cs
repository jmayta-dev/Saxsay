using Microsoft.Extensions.DependencyInjection;
using MW.SAXSAY.Core.Application.Contracts.Services;
using MW.SAXSAY.Core.Application.Services;

namespace MW.SAXSAY.Core.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        var applicationAssembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(
            config => config.RegisterServicesFromAssembly(applicationAssembly));

        services.AddServices();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IIdentifierGenerationService, TimestampedIdentifierGenerationService>();
    }
}
