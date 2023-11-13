using Quixpenses.App.Handlers.Auth;
using Quixpenses.App.Handlers.NewTransaction;
using Quixpenses.App.Handlers.UserSettings;
using Quixpenses.App.Models;

namespace Quixpenses.App.Handlers.HandlerSelection;

public class HandlerSelector(
        IAuthHandler authHandler,
        INewTransactionHandler newTransactionHandler,
        ISettingsModificationHandler settingsModificationHandler)
    : IHandlerSelector
{
    public IHandler? SelectHandler(IncomingMessage message)
    {
        IHandler? result = null;

        if (message.IsStartCommand())
        {
            result = authHandler;
        }
        else if (message.IsSetCommand())
        {
            result = settingsModificationHandler;
        }
        else if (message.IsNewTransactionCommand())
        {
            result = newTransactionHandler;
        }

        return result;
    }
}