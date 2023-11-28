using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.DatabaseAccess.Repositories.Users;

public interface IUsersRepository : IGenericRepository<User>
{
    Task<User?> TryGetByIdAsync(long id);

    Task<User?> TryGetByIdReadonlyAsync(long id);
}