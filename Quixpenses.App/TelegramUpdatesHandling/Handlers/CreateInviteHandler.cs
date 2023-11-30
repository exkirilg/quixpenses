using Microsoft.Extensions.Options;
using Quixpenses.App.Extensions;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.Interfaces;
using Quixpenses.Common.ConfigurationOptions;
using Quixpenses.Common.Exceptions;
using Quixpenses.Common.Models;
using Quixpenses.Services.Invites.Interfaces;
using Quixpenses.Services.Users.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Quixpenses.App.TelegramUpdatesHandling.Handlers;

public class CreateInviteHandler(
    ITelegramBotClient telegramBotClient,
    IOptions<TelegramBotOptions> telegramBotOptions,
    IUserAuthenticationService userAuthenticationService,
    ICreateInviteService createInviteService)
    : ICreateInviteHandler
{
    public async Task HandleAsync(Update update)
    {
        var userId = update.GetChatIdSafe();
        var user = await userAuthenticationService.AuthenticateAsync(userId);

        if (user.IsAuthorized is false) return;

        if (user.IsAdmin is false)
        {
            const string notAuthorizedMessage = "You are not authorized to create invites, please contact administrator";
            await telegramBotClient.SendTextMessageAsync(
                userId, notAuthorizedMessage, replyToMessageId: update.GetMessageId());
            return;
        }

        var (numberOfUses, availableForHours) = update.ParseNewInviteSettings();
        var expiresAt = DateTime.UtcNow.AddHours(availableForHours);

        Invite result;

        try
        {
            result = await createInviteService.CreateInviteAsync(numberOfUses, expiresAt);
        }
        catch (UnableToCreateInviteException ex)
        {
            const string unableToCreateInviteMessage = "Unable to create invite: {0}";
            await telegramBotClient.SendTextMessageAsync(userId, string.Format(unableToCreateInviteMessage, ex.Message));
            return;
        }

        var link = $"{telegramBotOptions.Value.Link}/?start={result.Id}";
        await telegramBotClient.SendTextMessageAsync(userId, link, replyToMessageId: update.GetMessageId());
    }
}