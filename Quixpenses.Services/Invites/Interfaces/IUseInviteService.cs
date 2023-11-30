using Quixpenses.Common.Models;

namespace Quixpenses.Services.Invites.Interfaces;

public interface IUseInviteService
{
    Task TryUseInviteAsync(User user, Guid inviteId);
}