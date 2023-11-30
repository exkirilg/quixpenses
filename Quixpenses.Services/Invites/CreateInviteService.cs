using System.ComponentModel.DataAnnotations;
using Quixpenses.Common.Exceptions;
using Quixpenses.Common.Models;
using Quixpenses.DatabaseAccess;
using Quixpenses.Services.Invites.Interfaces;

namespace Quixpenses.Services.Invites;

public class CreateInviteService(UnitOfWork unitOfWork)
    : ICreateInviteService
{
    public async Task<Invite> CreateInviteAsync(ushort numberOfUses, DateTime expiresAt)
    {
        var result = new Invite
        {
            Available = numberOfUses,
            ExpiresAt = expiresAt,
        };

        var validationResults = result.Validate(new ValidationContext(result)).ToArray();
        if (validationResults.Length != 0)
        {
            throw new UnableToCreateInviteException(string.Join(", ", validationResults.Select(x => x.ErrorMessage)));
        }

        await unitOfWork.InvitesRepository.AddAsync(result);
        await unitOfWork.SaveChangesAsync();

        return result;
    }
}