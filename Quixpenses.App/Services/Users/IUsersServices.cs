using Quixpenses.App.Models;

namespace Quixpenses.App.Services.Users;

public interface IUsersServices
{
    Task<bool> IsAuthorizedAsync(long id);

    Task<bool> TryAuthorizeUserAsync(IncomingMessage message);
}