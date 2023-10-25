using Microsoft.EntityFrameworkCore;
using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.Repositories.Users;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    public UsersRepository(EfContext context) : base(context)
    {
    }

    public async Task<User?> TryGetByIdAsync(long id)
    {
        var result = await Context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<User?> TryGetByIdReadonlyAsync(long id)
    {
        var result = await Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }
}