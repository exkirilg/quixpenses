using Quixpenses.App.Guards;
using Quixpenses.App.Models;
using Quixpenses.App.Services.Transactions;
using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.Handlers.NewTransaction;

public class NewTransactionHandler(
        ITransactionsService transactionsService)
    : INewTransactionHandler
{
    public async Task HandleAsync(User? user, IncomingMessage message)
    {
        Guard.AgainstUnauthorizedUser(user);
        await transactionsService.NewTransactionAsync(user!, message);
    }
}