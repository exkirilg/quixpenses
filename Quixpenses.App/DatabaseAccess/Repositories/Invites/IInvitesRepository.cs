using Quixpenses.App.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.DatabaseAccess.Repositories.Invites;

public interface IInvitesRepository
{
    Task<DbInvite?> TryGetByIdAsync(Guid id);

    Task AddAsync(DbInvite entity);

    Task SaveChangesAsync();
}