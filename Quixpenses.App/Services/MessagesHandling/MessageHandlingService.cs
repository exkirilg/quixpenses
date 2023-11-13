using Quixpenses.App.Exceptions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Quixpenses.App.Guards;
using Quixpenses.App.Handlers.HandlerSelection;
using Quixpenses.App.Models;
using Quixpenses.App.Resources;
using Quixpenses.App.Services.Users;

namespace Quixpenses.App.Services.MessagesHandling;

public class MessageHandlingService(
        ILogger<MessageHandlingService> logger,
        ITelegramBotClient telegramBotClient,
        IUsersServices usersServices,
        IHandlerSelector handlerSelector)
    : IMessageHandlingService
{
    public async Task HandleUpdateAsync(Update update)
    {
        logger.LogInformation(
            "Handling update for chat {chatId} {message}",
            update.Message?.Chat.Id,
            update.Message?.Text);

        var message = IncomingMessage.TryParse(update);
        Guard.AgainstUnknownUpdateType(message);

        var user = await usersServices.TryGetUserReadonlyAsync(message!.ChatId);

        var handler = handlerSelector.SelectHandler(message);
        Guard.AgainstNotImplementedHandler(handler);

        try
        {
            await handler!.HandleAsync(user, message);
        }
        catch (UnauthorizedException)
        {
            await telegramBotClient.SendTextMessageAsync(message.ChatId, Localization.Unauthorized);
            throw;
        }
    }
}