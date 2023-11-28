using Quixpenses.App.Models;
using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.Services.Transactions;

public interface ITransactionsService
{
    Task NewTransactionAsync(User user, IncomingMessage message);
}