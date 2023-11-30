using Quixpenses.Common.Models;

namespace Quixpenses.Services.Transactions.Interfaces;

public interface ICreateTransactionService
{
    Task CreateTransactionAsync(User user, float sum, Currency currency, Category? category);
}