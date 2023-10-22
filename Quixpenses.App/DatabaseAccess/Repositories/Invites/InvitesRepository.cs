using Microsoft.EntityFrameworkCore;
using Quixpenses.App.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.DatabaseAccess.Repositories.Invites;

public class InvitesRepository : GenericRepository<DbInvite>, IInvitesRepository
{
    public InvitesRepository(EfContext context) : base(context)
    {
    }

    public async Task<DbInvite?> TryGetByIdAsync(Guid id)
    {
        var result = await Context.Invites.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }
}