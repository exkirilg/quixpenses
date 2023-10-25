using Quixpenses.App.Exceptions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Quixpenses.App.Guards;
using Quixpenses.App.Handlers.HandlerSelection;
using Quixpenses.App.Models;
using Quixpenses.App.Resources;
using Quixpenses.App.Services.Users;

namespace Quixpenses.App.Services.MessagesHandling;

public class MessageHandlingService : IMessageHandlingService
{
    private readonly ILogger<MessageHandlingService> _logger;
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IUsersServices _usersServices;
    private readonly IHandlerSelector _handlerSelector;

    public MessageHandlingService(
        ILogger<MessageHandlingService> logger,
        ITelegramBotClient telegramBotClient,
        IUsersServices usersServices,
        IHandlerSelector handlerSelector)
    {
        _logger = logger;
        _telegramBotClient = telegramBotClient;
        _usersServices = usersServices;
        _handlerSelector = handlerSelector;
    }

    public async Task HandleUpdateAsync(Update update)
    {
        _logger.LogInformation(
            "Handling update for chat {chatId} {message}",
            update.Message?.Chat.Id,
            update.Message?.Text);

        var message = IncomingMessage.TryParse(update);
        Guard.AgainstUnknownUpdateType(message);

        var user = await _usersServices.TryGetUserReadonlyAsync(message!.ChatId);

        var handler = _handlerSelector.SelectHandler(message);
        Guard.AgainstNotImplementedHandler(handler);

        try
        {
            await handler!.HandleAsync(user, message);
        }
        catch (UnauthorizedException)
        {
            await _telegramBotClient.SendTextMessageAsync(message.ChatId, Localization.Unauthorized);
            throw;
        }
    }
}