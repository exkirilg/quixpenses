using Quixpenses.App.Extensions;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Interfaces;
using Telegram.Bot.Types;

namespace Quixpenses.App.TelegramUpdatesHandling;

public class UpdatesHandlerSelectionService(
    IUserAuthHandler userAuthHandler,
    ICreateInviteHandler createInviteHandler,
    IUpdateUserSettingsHandler updateUserSettingsHandler,
    ICreateTransactionHandler createTransactionHandler)
    : IUpdateHandlerSelectionService
{
    public IUpdateHandler? SelectHandler(Update update)
    {
        if (update.IsStartCommand()) return userAuthHandler;

        if (update.IsCreateInviteCommand()) return createInviteHandler;

        if (update.IsUpdateUserSettingsCommand()) return updateUserSettingsHandler;

        if (update.IsCreateTransactionCommand()) return createTransactionHandler;

        return default;
    }
}