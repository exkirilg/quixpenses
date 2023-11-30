using Quixpenses.Common.Models;

namespace Quixpenses.DatabaseAccess.Repositories.Invites;

public interface IInvitesRepository : IGenericRepository<Invite>
{
    Task<Invite?> TryGetByIdAsync(Guid id);
}