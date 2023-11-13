using Microsoft.EntityFrameworkCore;
using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.Repositories.Invites;

public class InvitesRepository(
        EfContext context)
    : GenericRepository<Invite>(context), IInvitesRepository
{
    public async Task<Invite?> TryGetByIdAsync(Guid id)
    {
        var result = await Context.Invites.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }
}