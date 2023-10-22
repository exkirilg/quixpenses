using Microsoft.Extensions.Options;
using Quixpenses.App.ConfigurationOptions;
using Quixpenses.App.DatabaseAccess.DatabaseModels;
using Quixpenses.App.DatabaseAccess.Repositories.Invites;

namespace Quixpenses.App.Services.Invites;

public class InvitesServices : IInvitesServices
{
   private readonly IOptions<TelegramBotOptions> _telegramBotOptions;
   private readonly IInvitesRepository _invitesRepository;

   public InvitesServices(
      IOptions<TelegramBotOptions> telegramBotOptions,
      IInvitesRepository invitesRepository)
   {
      _telegramBotOptions = telegramBotOptions;
      _invitesRepository = invitesRepository;
   }

   public async Task<string> CreateInviteAsync()
   {
      var dbInvite = new DbInvite
      {
         Available = 1,
         ExpiresAt = DateTime.UtcNow.AddDays(1),
      };

      await _invitesRepository.AddAsync(dbInvite);
      await _invitesRepository.SaveChangesAsync();

      var result = $"{_telegramBotOptions.Value.Link}/?start={dbInvite.Id}";

      return result;
   }

   public async Task<bool> TryUseInviteAsync(string invite)
   {
      if (!Guid.TryParse(invite.Replace("/start ", ""), out var inviteId))
      {
         return false;
      }

      var dbInvite = await _invitesRepository.TryGetByIdAsync(inviteId);

      if (dbInvite is null || dbInvite.Available <= dbInvite.Used || DateTime.UtcNow >= dbInvite.ExpiresAt)
      {
         return false;
      }

      dbInvite.Used++;
      await _invitesRepository.SaveChangesAsync();

      return true;
   }
}