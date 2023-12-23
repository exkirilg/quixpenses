using Quixpenses.Common.Models.DbModels;
using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.Services.Users.Interfaces;

namespace Quixpenses.Services.Users;

public class UserAuthenticationService(IUnitOfWork unitOfWork) : IUserAuthenticationService
{
    public Task<User?> TryAuthenticateAsync(long userId)
    {
        return unitOfWork.UsersRepository.TryGetByIdAsync(userId);
    }
}