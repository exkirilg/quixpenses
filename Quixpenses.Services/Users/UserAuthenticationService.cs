using Quixpenses.Common.Exceptions;
using Quixpenses.Common.Models;
using Quixpenses.DatabaseAccess;
using Quixpenses.Services.Users.Interfaces;

namespace Quixpenses.Services.Users;

public class UserAuthenticationService(UnitOfWork unitOfWork) : IUserAuthenticationService
{
    public Task<User?> TryAuthenticateAsync(long userId)
    {
        return unitOfWork.UsersRepository.TryGetByIdAsync(userId);
    }

    public async Task<User> AuthenticateAsync(long userId)
    {
        var result = await unitOfWork.UsersRepository.TryGetByIdAsync(userId);
        UserNotFoundException.ThrowIfNull(result);
        return result!;
    }
}