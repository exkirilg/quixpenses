using Quixpenses.App.Models;
using Quixpenses.App.Resources;
using Quixpenses.App.Services.Users;
using Telegram.Bot;

namespace Quixpenses.App.Handlers.Auth;

public class AuthHandler : IAuthHandler
{
    private readonly IUsersServices _usersServices;
    private readonly ITelegramBotClient _telegramBotClient;

    public AuthHandler(
        IUsersServices usersServices,
        ITelegramBotClient telegramBotClient)
    {
        _usersServices = usersServices;
        _telegramBotClient = telegramBotClient;
    }

    public async Task HandleAsync(User? user, IncomingMessage message)
    {
        if (UserIsAlreadyAuthorized(user))
        {
            return;
        }

        var result = await _usersServices.TryAuthorizeUserAsync(message);

        if (result)
        {
            await _telegramBotClient.SendTextMessageAsync(message.ChatId, Localization.Welcome);
        }
        else
        {
            await _telegramBotClient.SendTextMessageAsync(message.ChatId, Localization.BadInvite);
        }
    }

    private bool UserIsAlreadyAuthorized(User? user)
    {
        return user is not null && user.IsAuthorized;
    }
}