using Microsoft.EntityFrameworkCore;
using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.DatabaseAccess.Repositories.Users;

public class UsersRepository(
        EfContext context)
    : GenericRepository<User>(context), IUsersRepository
{
    public async Task<User?> TryGetByIdAsync(long id)
    {
        var result = await Context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<User?> TryGetByIdReadonlyAsync(long id)
    {
        var result = await Context.Users
            .AsNoTracking()
            .Include(x => x.UserSettings).ThenInclude(x => x!.Currency)
            .FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }
}