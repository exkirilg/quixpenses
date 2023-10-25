using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.Repositories.Invites;

public interface IInvitesRepository : IGenericRepository<Invite>
{
    Task<Invite?> TryGetByIdAsync(Guid id);
}