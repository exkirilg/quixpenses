using Quixpenses.App.Guards;
using Quixpenses.App.Models;
using Quixpenses.App.Services.Transactions;

namespace Quixpenses.App.Handlers.NewTransaction;

public class NewTransactionHandler : INewTransactionHandler
{
    private readonly ITransactionsService _transactionsService;

    public NewTransactionHandler(
        ITransactionsService transactionsService)
    {
        _transactionsService = transactionsService;
    }

    public async Task HandleAsync(User? user, IncomingMessage message)
    {
        Guard.AgainstUnauthorizedUser(user);
        await _transactionsService.NewTransactionAsync(user!, message);
    }
}