using Quixpenses.App.Guards;
using Quixpenses.App.Models;
using Quixpenses.DatabaseAccess.DatabaseModels;
using Quixpenses.DatabaseAccess.UnitOfWork;

namespace Quixpenses.App.Services.Transactions;

public class TransactionsService(
        IUnitOfWork unitOfWork)
    : ITransactionsService
{
    public async Task NewTransactionAsync(User user, IncomingMessage message)
    {
        var (sum, currencyCode) = message.ParseTransaction();

        Currency? currency;
        if (string.IsNullOrWhiteSpace(currencyCode))
        {
            currency = user.UserSettings?.Currency;
        }
        else
        {
            currency = await unitOfWork.CurrenciesRepository.TryGetByIdReadonlyAsync(currencyCode);
        }
        Guard.AgainstCurrencyNotFound(currency);

        var transaction = new Transaction
        {
            UserId = user.Id,
            CurrencyId = currency!.Id,
            Sum = (int)(Math.Round(sum, currency.FractionDigits) * Math.Pow(10, currency.FractionDigits)),
        };

        await unitOfWork.TransactionsRepository.AddAsync(transaction);
        await unitOfWork.SaveChangesAsync();
    }
}