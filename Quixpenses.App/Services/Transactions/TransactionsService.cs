using Quixpenses.App.DatabaseAccess.UnitOfWork;
using Quixpenses.App.Guards;
using Quixpenses.App.Models;

namespace Quixpenses.App.Services.Transactions;

public class TransactionsService : ITransactionsService
{
    private readonly IUnitOfWork _unitOfWork;

    public TransactionsService(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task NewTransactionAsync(User user, IncomingMessage message)
    {
        var (sum, currencyCode) = message.ParseTransaction();

        var currency = await _unitOfWork.CurrenciesRepository.TryGetByIdReadonlyAsync(currencyCode);
        Guard.AgainstCurrencyNotFound(currency, currencyCode);

        var transaction = new Transaction
        {
            UserId = user.Id,
            CurrencyId = currency!.Id,
            Sum = (int)(Math.Round(sum, currency.FractionDigits) * Math.Pow(10, currency.FractionDigits)),
        };

        await _unitOfWork.TransactionsRepository.AddAsync(transaction);
        await _unitOfWork.SaveChangesAsync();
    }
}