using Quixpenses.App.Models;
using Quixpenses.App.Resources;
using Quixpenses.App.Services.Users;
using Quixpenses.DatabaseAccess.DatabaseModels;
using Telegram.Bot;

namespace Quixpenses.App.Handlers.Auth;

public class AuthHandler(
        IUsersServices usersServices,
        ITelegramBotClient telegramBotClient)
    : IAuthHandler
{
    public async Task HandleAsync(User? user, IncomingMessage message)
    {
        if (UserIsAlreadyAuthorized(user))
        {
            return;
        }

        var result = await usersServices.TryAuthorizeUserAsync(message);

        if (!result)
        {
            await telegramBotClient.SendTextMessageAsync(message.ChatId, Localization.BadInvite);
        }
    }

    private bool UserIsAlreadyAuthorized(User? user)
    {
        return user is not null && user.IsAuthorized;
    }
}