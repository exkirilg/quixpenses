using Quixpenses.App.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.DatabaseAccess.Repositories.Users;

public interface IUsersRepository
{
    Task<DbUser?> TryGetByIdAsync(long id);

    Task<DbUser?> TryGetByIdReadonlyAsync(long id);

    Task AddAsync(DbUser entity);

    Task SaveChangesAsync();
}