using Quixpenses.Common.Models;

namespace Quixpenses.Services.Users.Interfaces;

public interface IUserAuthenticationService
{
    Task<User?> TryAuthenticateAsync(long userId);

    Task<User> AuthenticateAsync(long userId);
}