using Quixpenses.App.Extensions;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.Interfaces;
using Quixpenses.Common.Models;
using Quixpenses.Services.Currencies.Interfaces;
using Quixpenses.Services.Transactions.Interfaces;
using Quixpenses.Services.Users.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = Quixpenses.Common.Models.User;

namespace Quixpenses.App.TelegramUpdatesHandling.Handlers;

public class CreateTransactionHandler(
    ITelegramBotClient telegramBotClient,
    IUserAuthenticationService userAuthenticationService,
    IGetCurrencyService getCurrencyService,
    ICreateTransactionService createTransactionService)
    : ICreateTransactionHandler
{
    public async Task HandleAsync(Update update)
    {
        var userId = update.GetChatIdSafe();
        var user = await userAuthenticationService.AuthenticateAsync(userId);

        if (user.IsAuthorized is false) return;

        var (currency, sum) = await ParseTransactionSettings(update, user);

        if (currency is null)
        {
            const string unknownCurrencyCodeMessage = "Unknown currency code";
            await telegramBotClient.SendTextMessageAsync(
                user.Id, unknownCurrencyCodeMessage, replyToMessageId: update.GetMessageId());
            return;
        }

        await createTransactionService.CreateTransactionAsync(user, sum, currency);
    }

    private async Task<(Currency? currency, float sum)> ParseTransactionSettings(Update update, User user)
    {
        var (sum, currencyCode) = update.ParseTransaction();

        Currency? currency;
        if (currencyCode == string.Empty)
        {
            currency = user.Settings?.Currency;
        }
        else
        {
            currency = await getCurrencyService.TryGetCurrencyAsync(currencyCode);
        }

        return (currency, sum);
    }
}