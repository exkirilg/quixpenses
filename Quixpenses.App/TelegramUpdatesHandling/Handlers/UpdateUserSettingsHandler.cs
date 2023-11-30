using Quixpenses.App.Extensions;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.Interfaces;
using Quixpenses.Services.Currencies.Interfaces;
using Quixpenses.Services.Users.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = Quixpenses.Common.Models.User;

namespace Quixpenses.App.TelegramUpdatesHandling.Handlers;

public class UpdateUserSettingsHandler(
    IUserAuthenticationService userAuthenticationService,
    IUserSettingsService userSettingsService,
    IGetCurrencyService getCurrencyService,
    ITelegramBotClient telegramBotClient)
    : IUpdateUserSettingsHandler
{
    public async Task HandleAsync(Update update)
    {
        var userId = update.GetChatIdSafe();
        var user = await userAuthenticationService.AuthenticateAsync(userId);

        if (user.IsAuthorized is false) return;

        var (settingName, settingValue) = update.ParseSettingsUpdateValues();

        switch (settingName)
        {
            case "currency":
                await UpdateCurrencySetting(user, settingValue.Trim().ToUpper(), update);
                break;
            default:
                throw new NotImplementedException();
        }
    }

    private async Task UpdateCurrencySetting(User user, string currencyCode, Update update)
    {
        var currency = await getCurrencyService.TryGetCurrencyAsync(currencyCode);

        if (currency is null)
        {
            const string unknownCurrencyCodeMessage = "Unknown currency code";
            await telegramBotClient.SendTextMessageAsync(
                user.Id, unknownCurrencyCodeMessage, replyToMessageId: update.GetMessageId());
            return;
        }

        await userSettingsService.SetUserCurrency(user, currency);
    }
}