using Quixpenses.App.DatabaseAccess.Repositories.Invites;
using Quixpenses.App.DatabaseAccess.Repositories.Users;

namespace Quixpenses.App.DatabaseAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly EfContext _context;

    public UnitOfWork(
        EfContext context,
        IInvitesRepository invitesRepository,
        IUsersRepository usersRepository)
    {
        _context = context;
        InvitesRepository = invitesRepository;
        UsersRepository = usersRepository;
    }

    public IInvitesRepository InvitesRepository { get; }

    public IUsersRepository UsersRepository { get; }

    public async Task SaveChangesAsync()
    {
        await this._context.SaveChangesAsync();
    }
}