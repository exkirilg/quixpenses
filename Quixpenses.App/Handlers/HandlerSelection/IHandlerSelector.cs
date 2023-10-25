using Quixpenses.App.Models;

namespace Quixpenses.App.Handlers.HandlerSelection;

public interface IHandlerSelector
{
    IHandler? SelectHandler(IncomingMessage message);
}