using Quixpenses.App.Models;
using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.Handlers;

public interface IHandler
{
    Task HandleAsync(User? user, IncomingMessage message);
}