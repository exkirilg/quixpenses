using Quixpenses.App.Models;

namespace Quixpenses.App.Services.Users;

public interface IUsersServices
{
    Task<User?> TryGetUserReadonlyAsync(long id);

    Task<bool> TryAuthorizeUserAsync(IncomingMessage message);

    Task SetUserCurrencyAsync(User user, string currencyCode);
}