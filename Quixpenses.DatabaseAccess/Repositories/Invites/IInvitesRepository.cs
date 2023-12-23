using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.DatabaseAccess.Repositories.Invites;

public interface IInvitesRepository : IGenericRepository<Invite>
{
    Task<Invite?> TryGetByIdAsync(Guid id);
}