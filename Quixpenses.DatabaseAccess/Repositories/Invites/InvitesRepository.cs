using Quixpenses.Common.Models;

namespace Quixpenses.DatabaseAccess.Repositories.Invites;

public class InvitesRepository(EfContext context) : GenericRepository<Invite>(context), IInvitesRepository
{
    public async Task<Invite?> TryGetByIdAsync(Guid id)
    {
        return await Context.Invites.FindAsync(id);
    }
}