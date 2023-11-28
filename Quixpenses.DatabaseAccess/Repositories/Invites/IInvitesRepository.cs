using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.DatabaseAccess.Repositories.Invites;

public interface IInvitesRepository : IGenericRepository<Invite>
{
    Task<Invite?> TryGetByIdAsync(Guid id);
}