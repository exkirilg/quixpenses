using Quixpenses.App.DatabaseAccess.Repositories.Invites;
using Quixpenses.App.DatabaseAccess.Repositories.Users;

namespace Quixpenses.App.DatabaseAccess.UnitOfWork;

public interface IUnitOfWork
{
    IInvitesRepository InvitesRepository { get; }

    IUsersRepository UsersRepository { get; }

    Task SaveChangesAsync();
}