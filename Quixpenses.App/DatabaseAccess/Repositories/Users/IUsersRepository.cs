using Quixpenses.App.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.DatabaseAccess.Repositories.Users;

public interface IUsersRepository : IGenericRepository<DbUser>
{
    Task<DbUser?> TryGetByIdAsync(long id);

    Task<DbUser?> TryGetByIdReadonlyAsync(long id);
}