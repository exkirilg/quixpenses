using Microsoft.EntityFrameworkCore;
using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.Repositories.Invites;

public class InvitesRepository : GenericRepository<Invite>, IInvitesRepository
{
    public InvitesRepository(EfContext context) : base(context)
    {
    }

    public async Task<Invite?> TryGetByIdAsync(Guid id)
    {
        var result = await Context.Invites.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }
}