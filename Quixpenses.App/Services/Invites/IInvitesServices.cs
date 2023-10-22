namespace Quixpenses.App.Services.Invites;

public interface IInvitesServices
{
    Task<string> CreateInviteAsync();

    Task<bool> TryUseInviteAsync(string invite);
}