using Microsoft.EntityFrameworkCore;
using Quixpenses.App.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.DatabaseAccess.Repositories.Invites;

public class InvitesRepository : IInvitesRepository
{
    private readonly EfContext _context;

    public InvitesRepository(EfContext context)
    {
        _context = context;
    }

    public async Task<DbInvite?> TryGetByIdAsync(Guid id)
    {
        var result = await _context.Invites.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task AddAsync(DbInvite entity)
    {
        await _context.Invites.AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}