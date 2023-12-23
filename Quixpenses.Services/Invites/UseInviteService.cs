using Microsoft.Extensions.Logging;
using Quixpenses.Common.Models.DbModels;
using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.Services.Invites.Interfaces;

namespace Quixpenses.Services.Invites;

public class UseInviteService(
    ILogger<UseInviteService> logger,
    IUnitOfWork unitOfWork)
    : IUseInviteService
{
    public async Task TryUseInviteAsync(User user, Guid inviteId)
    {
        var invite = await unitOfWork.InvitesRepository.TryGetByIdAsync(inviteId);

        if (invite is null)
        {
            logger.LogWarning("Unable to find invite by id {inviteId}", inviteId);
            return;
        }

        if (invite.Available <= invite.Used)
        {
            logger.LogInformation("Invite has been already used {inviteId}", inviteId);
            return;
        }

        if (DateTime.UtcNow >= invite.ExpiresAt)
        {
            logger.LogInformation("Invite has already expired {inviteId}", inviteId);
            return;
        }

        invite.Used++;
        user.IsAuthorized = true;

        await unitOfWork.SaveChangesAsync();
    }
}