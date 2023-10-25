using Quixpenses.App.Models;

namespace Quixpenses.App.Handlers;

public interface IHandler
{
    Task HandleAsync(User? user, IncomingMessage message);
}