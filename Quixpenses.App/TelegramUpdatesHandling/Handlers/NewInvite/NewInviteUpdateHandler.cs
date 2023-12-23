using Microsoft.Extensions.Options;
using Quixpenses.App.ConfigurationOptions;
using Quixpenses.App.Extensions;
using Quixpenses.App.TelegramMessaging.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.NewInvite.Interfaces;
using Quixpenses.Common.Models;
using Quixpenses.Common.Models.Commands;
using Quixpenses.Common.Models.DbModels;
using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.Services.Invites.Interfaces;
using Quixpenses.Services.Users.Interfaces;

namespace Quixpenses.App.TelegramUpdatesHandling.Handlers.NewInvite;

public class NewInviteUpdateHandler(
    IOptions<TelegramBotOptions> telegramBotOptions,
    IUnitOfWork unitOfWork,
    IUserSessionService userSessionService,
    IMessagingService messagingService,
    ICreateInviteService createInviteService)
    : INewInviteUpdateHandler
{
    public async Task HandleAsync(User user, UpdateData update)
    {
        var command = (user.CurrentSession!.Command as NewInviteCommand)! with { };

        command.TrySetPropertyValue(
            update.PropertySetterCallbackDataDto!.PropertyName,
            update.PropertySetterCallbackDataDto!.PropertyValue);

        if (command.IsFilled)
        {
            await FinalizeCommandAsync(update, user, command);
        }
        else
        {
            await BreakCommandAsync(update, user.CurrentSession, command);
        }
    }

    private async Task FinalizeCommandAsync(UpdateData update, User user, NewInviteCommand command)
    {
        var session = user.CurrentSession!;

        var invite = await createInviteService.CreateInviteAsync(
            command.NumberOfUses!.Value,
            DateTime.UtcNow.AddHours(command.HoursAvailable!.Value));

        user.CurrentSession = null;
        await unitOfWork.SaveChangesAsync();

        await RerenderSettingsKeyboard(update, session, command);

        var link = $"{telegramBotOptions.Value.Link}/?start={invite.Id}";
        await messagingService.SendTextMessageAsync(update.ChatId, link);
    }

    private async Task BreakCommandAsync(UpdateData update, Session session, NewInviteCommand command)
    {
        userSessionService.UpdateSession(session, command);
        await unitOfWork.SaveChangesAsync();
        await RerenderSettingsKeyboard(update, session, command);
    }

    private async Task RerenderSettingsKeyboard(UpdateData update, Session session, NewInviteCommand command)
    {
        var keyboard = command.GetCommandSettingsKeyboard(session);
        await messagingService.EditMessageKeyboardAsync(update.ChatId, command.SettingsMessageId, keyboard);
    }
}