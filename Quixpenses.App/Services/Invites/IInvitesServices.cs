namespace Quixpenses.App.Services.Invites;

public interface IInvitesServices
{
    Task<string> CreateInviteAsync();

    Task<bool> InviteIsActiveAsync(string invite);
}