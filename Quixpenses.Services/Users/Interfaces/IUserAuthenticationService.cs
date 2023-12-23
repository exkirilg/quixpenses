using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.Services.Users.Interfaces;

public interface IUserAuthenticationService
{
    Task<User?> TryAuthenticateAsync(long userId);
}