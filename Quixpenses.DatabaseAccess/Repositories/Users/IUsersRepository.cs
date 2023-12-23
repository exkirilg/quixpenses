using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.DatabaseAccess.Repositories.Users;

public interface IUsersRepository : IGenericRepository<User>
{
    Task<User?> TryGetByIdAsync(long id);
}