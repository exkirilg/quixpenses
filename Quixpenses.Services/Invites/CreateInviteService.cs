using Quixpenses.Common.Models.DbModels;
using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.Services.Invites.Interfaces;

namespace Quixpenses.Services.Invites;

public class CreateInviteService(IUnitOfWork unitOfWork)
    : ICreateInviteService
{
    public async Task<Invite> CreateInviteAsync(ushort numberOfUses, DateTime expiresAt)
    {
        var result = new Invite
        {
            Available = numberOfUses,
            ExpiresAt = expiresAt,
        };

        await unitOfWork.InvitesRepository.AddAsync(result);

        return result;
    }
}