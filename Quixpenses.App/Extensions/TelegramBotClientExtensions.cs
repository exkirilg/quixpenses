using Quixpenses.App.ConfigurationOptions;
using Quixpenses.Common.Models.Commands;
using Quixpenses.Common.Models.Commands.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Quixpenses.App.Extensions;

public static class TelegramBotClientExtensions
{
    public static async Task SetupWebhookAsync(
        this ITelegramBotClient telegramBotClient,
        TelegramBotOptions options,
        CancellationToken cancellationToken)
    {
        await telegramBotClient.SetWebhookAsync(
            url: $"{options.HostAddress}{options.Route}",
            allowedUpdates: Array.Empty<UpdateType>(),
            secretToken: options.SecretToken,
            cancellationToken: cancellationToken);
    }

    public static async Task SetupCommandsAsync(
        this ITelegramBotClient telegramBotClient,
        CancellationToken cancellationToken)
    {
        var commands = new ICommand[]
        {
            new NewExpenseCommand(),
            new SetDefaultCurrencyCommand(),
        }.Select(x => new BotCommand
        {
            Command = x.Name,
            Description = x.Description,
        });

        await telegramBotClient.SetMyCommandsAsync(
            commands: commands,
            cancellationToken: cancellationToken);
    }
}