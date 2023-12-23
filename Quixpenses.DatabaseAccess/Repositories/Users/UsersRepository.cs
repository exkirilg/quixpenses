using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.DatabaseAccess.Repositories.Users;

public class UsersRepository(EfContext context) : GenericRepository<User>(context), IUsersRepository
{
    public async Task<User?> TryGetByIdAsync(long id)
    {
        return await Context.Users.FindAsync(id);
    }
}