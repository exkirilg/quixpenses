using Quixpenses.Common.Models;

namespace Quixpenses.Services.Users.Interfaces;

public interface IUserCreationService
{
    Task<User> CreateUserAsync(long userId);
}