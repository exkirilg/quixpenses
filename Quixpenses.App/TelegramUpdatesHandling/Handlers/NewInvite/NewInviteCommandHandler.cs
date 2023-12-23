using Quixpenses.App.Extensions;
using Quixpenses.App.TelegramMessaging.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.NewInvite.Interfaces;
using Quixpenses.Common.Models;
using Quixpenses.Common.Models.Commands;
using Quixpenses.Common.Models.DbModels;
using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.Services.Users.Interfaces;

namespace Quixpenses.App.TelegramUpdatesHandling.Handlers.NewInvite;

public class NewInviteCommandHandler(
    IUnitOfWork unitOfWork,
    IUserSessionService userSessionServiceAsync,
    IMessagingService messagingService)
    : INewInviteCommandHandler
{
    public async Task HandleAsync(User user, UpdateData update)
    {
        if (user is not { IsAuthorized : true, IsAdmin: true })
        {
            return;
        }

        var session = new Session();
        var command = new NewInviteCommand();

        await RenderSettingsKeyboard(update, session, command);

        session.Command = command;
        userSessionServiceAsync.ResetSession(user, session);

        await unitOfWork.SaveChangesAsync();
    }

    private async Task RenderSettingsKeyboard(UpdateData update, Session session, NewInviteCommand command)
    {
        var keyboard = command.GetCommandSettingsKeyboard(session);

        var message = await messagingService.SendTextMessageAsync(
            update.ChatId, "setup invite", replyMarkup: keyboard);

        command.SettingsMessageId = message.MessageId;
    }
}