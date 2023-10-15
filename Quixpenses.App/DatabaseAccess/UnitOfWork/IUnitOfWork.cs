using Quixpenses.App.DatabaseAccess.Repositories.Invites;

namespace Quixpenses.App.DatabaseAccess.UnitOfWork;

public interface IUnitOfWork
{
    public IInvitesRepository InvitesRepository { get; }

    Task SaveChangesAsync();
}