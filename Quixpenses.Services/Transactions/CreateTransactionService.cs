using Quixpenses.Common.Models;
using Quixpenses.DatabaseAccess;
using Quixpenses.Services.Transactions.Interfaces;

namespace Quixpenses.Services.Transactions;

public class CreateTransactionService(UnitOfWork unitOfWork) : ICreateTransactionService
{
    public async Task CreateTransactionAsync(User user, float sum, Currency currency, Category? category)
    {
        var result = new Transaction
        {
            User = user,
            Currency = currency,
            Category = category,
            Sum = (int)(Math.Round(sum, currency.FractionDigits) * Math.Pow(10, currency.FractionDigits)),
        };

        await unitOfWork.TransactionsRepository.AddAsync(result);
        await unitOfWork.SaveChangesAsync();
    }
}