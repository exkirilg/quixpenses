using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.Services.Users.Interfaces;

public interface IUserCreationService
{
    Task<User> CreateUserAsync(long userId);
}