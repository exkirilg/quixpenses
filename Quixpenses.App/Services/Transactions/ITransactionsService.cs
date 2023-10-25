using Quixpenses.App.Models;

namespace Quixpenses.App.Services.Transactions;

public interface ITransactionsService
{
    Task NewTransactionAsync(User user, IncomingMessage message);
}