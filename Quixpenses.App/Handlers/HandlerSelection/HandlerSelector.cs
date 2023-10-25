using Quixpenses.App.Handlers.Auth;
using Quixpenses.App.Handlers.NewTransaction;
using Quixpenses.App.Models;

namespace Quixpenses.App.Handlers.HandlerSelection;

public class HandlerSelector : IHandlerSelector
{
    private readonly IAuthHandler _authHandler;
    private readonly INewTransactionHandler _newTransactionHandler;

    public HandlerSelector(
        IAuthHandler authHandler,
        INewTransactionHandler newTransactionHandler)
    {
        _authHandler = authHandler;
        _newTransactionHandler = newTransactionHandler;
    }

    public IHandler? SelectHandler(IncomingMessage message)
    {
        IHandler? result = null;

        if (message.IsStartCommand())
        {
            result = _authHandler;
        }
        else if (message.IsNewTransactionCommand())
        {
            result = _newTransactionHandler;
        }

        return result;
    }
}