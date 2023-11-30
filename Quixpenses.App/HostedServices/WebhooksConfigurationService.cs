using Microsoft.Extensions.Options;
using Quixpenses.Common.ConfigurationOptions;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

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

        var webhookAddress = $"{telegramBotOptions.HostAddress}{telegramBotOptions.Route}";
        logger.LogInformation("Setting webhook: {WebhookAddress}", webhookAddress);

        await telegramBotClient.SetWebhookAsync(
            url: webhookAddress,
            allowedUpdates: Array.Empty<UpdateType>(),
            secretToken: telegramBotOptions.SecretToken,
            cancellationToken: cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var telegramBotClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

        logger.LogInformation("Deleting webhook");
        await telegramBotClient.DeleteWebhookAsync(cancellationToken: cancellationToken);
    }
}