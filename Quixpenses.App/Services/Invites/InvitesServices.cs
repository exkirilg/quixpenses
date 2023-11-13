using Microsoft.Extensions.Options;
using Quixpenses.App.ConfigurationOptions;
using Quixpenses.App.DatabaseAccess.UnitOfWork;
using Quixpenses.App.Models;

namespace Quixpenses.App.Services.Invites;

public class InvitesServices(
      IOptions<TelegramBotOptions> telegramBotOptions,
      IUnitOfWork unitOfWork)
   : IInvitesServices
{
   public async Task<string> CreateInviteAsync()
   {
      var dbInvite = new Invite
      {
         Available = 1,
         ExpiresAt = DateTime.UtcNow.AddDays(1),
      };

      await unitOfWork.InvitesRepository.AddAsync(dbInvite);
      await unitOfWork.SaveChangesAsync();

      var result = $"{telegramBotOptions.Value.Link}/?start={dbInvite.Id}";

      return result;
   }

   public async Task<bool> TryUseInviteAsync(string invite)
   {
      if (!Guid.TryParse(invite.Replace("/start ", ""), out var inviteId))
      {
         return false;
      }

      var dbInvite = await unitOfWork.InvitesRepository.TryGetByIdAsync(inviteId);

      if (dbInvite is null || dbInvite.Available <= dbInvite.Used || DateTime.UtcNow >= dbInvite.ExpiresAt)
      {
         return false;
      }

      dbInvite.Used++;
      await unitOfWork.SaveChangesAsync();

      return true;
   }
}