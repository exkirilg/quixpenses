using Quixpenses.App.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.DatabaseAccess.Repositories.Invites;

public interface IInvitesRepository : IGenericRepository<DbInvite>
{
    Task<DbInvite?> TryGetByIdAsync(Guid id);
}