using Quixpenses.App.TelegramMessaging.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.Start.Interfaces;
using Quixpenses.Common.Models;
using Quixpenses.Common.Models.DbModels;
using Quixpenses.Services.Invites.Interfaces;

namespace Quixpenses.App.TelegramUpdatesHandling.Handlers.Start;

public class StartCommandHandler(
    IUseInviteService useInviteService,
    IMessagingService messagingService)
    : IStartCommandHandler
{
    public async Task HandleAsync(User user, UpdateData update)
    {
        if (user.IsAuthorized is false && update.TryParseStartCommandInviteId(out var inviteId))
        {
            await useInviteService.TryUseInviteAsync(user, inviteId);
        }

        if (user.IsAuthorized is false)
        {
            const string badInviteMessage = "There is problem with your invitation, please contact administration";
            await messagingService.SendTextMessageAsync(update.ChatId, badInviteMessage);
        }
    }
}