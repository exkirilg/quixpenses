using Quixpenses.App.Extensions;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.Interfaces;
using Quixpenses.Services.Invites.Interfaces;
using Quixpenses.Services.Users.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Quixpenses.App.TelegramUpdatesHandling.Handlers;

public class UserAuthHandler(
    ITelegramBotClient telegramBotClient,
    IUserAuthenticationService userAuthenticationService,
    IUserCreationService userCreationService,
    IUseInviteService useInviteService)
    : IUserAuthHandler
{
    public async Task HandleAsync(Update update)
    {
        var userId = update.GetChatIdSafe();
        if (userId is 0) throw new Exception("Unable to get user id");

        var user = await userAuthenticationService.TryAuthenticateAsync(userId);
        if (user?.IsAuthorized is true) return;

        user ??= await userCreationService.CreateUserAsync(userId);

        if (update.TryParseInviteId(out var inviteId))
        {
            await useInviteService.TryUseInviteAsync(user, inviteId);
        }

        if (user.IsAuthorized is false)
        {
            const string badInviteMessage = "There is problem with your invitation, please contact administration";
            await telegramBotClient.SendTextMessageAsync(userId, badInviteMessage);
        }
    }
}