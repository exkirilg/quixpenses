using Microsoft.EntityFrameworkCore;
using Quixpenses.App.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.DatabaseAccess.Repositories.Invites;

public class InvitesRepository : AbstractRepository<DbInvite>, IInvitesRepository
{
    public InvitesRepository(DbSet<DbInvite> dbSet) : base(dbSet)
    {
    }

    public async Task<DbInvite?> TryGetByIdAsync(Guid id)
    {
        var result = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }
}