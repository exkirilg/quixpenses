using Quixpenses.App.DatabaseAccess.DatabaseModels;
using Quixpenses.App.DatabaseAccess.Repositories.Invites;

namespace Quixpenses.App.DatabaseAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly EfContext _context;

    private IInvitesRepository? _invitesRepository;

    public UnitOfWork(EfContext context)
    {
        _context = context;
    }

    public IInvitesRepository InvitesRepository =>
        _invitesRepository ??= new InvitesRepository(_context.Set<DbInvite>());

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}