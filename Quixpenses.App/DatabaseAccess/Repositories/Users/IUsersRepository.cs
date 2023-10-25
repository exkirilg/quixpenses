using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.Repositories.Users;

public interface IUsersRepository : IGenericRepository<User>
{
    Task<User?> TryGetByIdAsync(long id);

    Task<User?> TryGetByIdReadonlyAsync(long id);
}