using Quixpenses.App.HostedServices;

namespace Quixpenses.App.DIConfiguration;

public static class HostedServicesConfigurationExtensions
{
    public static IServiceCollection ConfigureHostedServices(this IServiceCollection services)
    {
        services.AddHostedService<WebhooksConfigurationService>();
        return services;
    }
}