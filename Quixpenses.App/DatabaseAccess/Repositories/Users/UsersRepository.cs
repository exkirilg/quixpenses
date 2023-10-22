using Microsoft.EntityFrameworkCore;
using Quixpenses.App.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.DatabaseAccess.Repositories.Users;

public class UsersRepository : GenericRepository<DbUser>, IUsersRepository
{
    public UsersRepository(EfContext context) : base(context)
    {
    }

    public async Task<DbUser?> TryGetByIdAsync(long id)
    {
        var result = await Context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<DbUser?> TryGetByIdReadonlyAsync(long id)
    {
        var result = await Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }
}