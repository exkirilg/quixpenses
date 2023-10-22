using Microsoft.Extensions.Options;
using Quixpenses.App.ConfigurationOptions;
using Quixpenses.App.DatabaseAccess.DatabaseModels;
using Quixpenses.App.DatabaseAccess.UnitOfWork;

namespace Quixpenses.App.Services.Invites;

public class InvitesServices : IInvitesServices
{
   private readonly IOptions<TelegramBotOptions> _telegramBotOptions;
   private readonly IUnitOfWork _unitOfWork;

   public InvitesServices(
      IOptions<TelegramBotOptions> telegramBotOptions,
      IUnitOfWork unitOfWork)
   {
      _telegramBotOptions = telegramBotOptions;
      _unitOfWork = unitOfWork;
   }

   public async Task<string> CreateInviteAsync()
   {
      var dbInvite = new DbInvite
      {
         Available = 1,
         ExpiresAt = DateTime.UtcNow.AddDays(1),
      };

      await _unitOfWork.InvitesRepository.AddAsync(dbInvite);
      await _unitOfWork.SaveChangesAsync();

      var result = $"{_telegramBotOptions.Value.Link}/?start={dbInvite.Id}";

      return result;
   }

   public async Task<bool> TryUseInviteAsync(string invite)
   {
      if (!Guid.TryParse(invite.Replace("/start ", ""), out var inviteId))
      {
         return false;
      }

      var dbInvite = await _unitOfWork.InvitesRepository.TryGetByIdAsync(inviteId);

      if (dbInvite is null || dbInvite.Available <= dbInvite.Used || DateTime.UtcNow >= dbInvite.ExpiresAt)
      {
         return false;
      }

      dbInvite.Used++;
      await _unitOfWork.SaveChangesAsync();

      return true;
   }
}