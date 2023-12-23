using Microsoft.Extensions.Options;
using Quixpenses.App.ConfigurationOptions;
using Quixpenses.App.Extensions;
using Telegram.Bot;

namespace Quixpenses.App.HostedServices;

public class WebhooksConfigurationService(
        ILogger<WebhooksConfigurationService> logger,
        IServiceProvider serviceProvider,
        IOptions<TelegramBotOptions> options)
    : IHostedService
{
    private readonly TelegramBotOptions telegramBotOptions = options.Value;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var telegramBotClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

        await telegramBotClient.SetupWebhookAsync(options.Value, cancellationToken);
        await telegramBotClient.SetupCommandsAsync(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var telegramBotClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

        logger.LogInformation("Deleting webhook");
        await telegramBotClient.DeleteWebhookAsync(cancellationToken: cancellationToken);
    }
}