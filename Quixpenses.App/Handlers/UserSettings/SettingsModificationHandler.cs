using Quixpenses.App.Exceptions;
using Quixpenses.App.Guards;
using Quixpenses.App.Models;
using Quixpenses.App.Resources;
using Quixpenses.App.Services.Users;
using Quixpenses.DatabaseAccess.DatabaseModels;
using Telegram.Bot;

namespace Quixpenses.App.Handlers.UserSettings;

public class SettingsModificationHandler(
        IUsersServices usersServices,
        ITelegramBotClient telegramBotClient)
    : ISettingsModificationHandler
{
    public async Task HandleAsync(User? user, IncomingMessage message)
    {
        Guard.AgainstUnauthorizedUser(user);

        var (settings, value) = message.ParseSettingsModification();

        switch (settings)
        {
            case "currency":
                await SetUserCurrency(user!, value);
                break;
            default:
                await telegramBotClient.SendTextMessageAsync(
                    user!.Id,
                    string.Format(Localization.UnknownSetting, settings));
                break;
        }
    }

    private async Task SetUserCurrency(User user, string currencyCode)
    {
        var currencyCodeNormalized = currencyCode.Trim().ToUpper();

        try
        {
            await usersServices.SetUserCurrencyAsync(user, currencyCodeNormalized);
        }
        catch (UnknownCurrencyCode)
        {
            await telegramBotClient.SendTextMessageAsync(
                user.Id,
                string.Format(Localization.UnknownCurrency, currencyCodeNormalized));
        }
    }
}