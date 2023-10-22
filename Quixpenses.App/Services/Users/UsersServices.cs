using Quixpenses.App.DatabaseAccess.DatabaseModels;
using Quixpenses.App.DatabaseAccess.Repositories.Users;
using Quixpenses.App.Models;
using Quixpenses.App.Services.Invites;

namespace Quixpenses.App.Services.Users;

public class UsersServices : IUsersServices
{
    private readonly IUsersRepository _usersRepository;
    private readonly IInvitesServices _invitesServices;

    public UsersServices(
        IUsersRepository usersRepository,
        IInvitesServices invitesServices)
    {
        _usersRepository = usersRepository;
        _invitesServices = invitesServices;
    }

    public async Task<bool> IsAuthorizedAsync(long id)
    {
        var dbUser = await _usersRepository.TryGetByIdReadonlyAsync(id);
        return dbUser?.IsAuthorized ?? false;
    }

    public async Task<bool> TryAuthorizeUserAsync(IncomingMessage message)
    {
        var inviteAvailable = await _invitesServices.TryUseInviteAsync(message.Text);

        var dbUser = await _usersRepository.TryGetByIdAsync(message.ChatId);

        var newUser = dbUser is null;

        if (newUser)
        {
            dbUser = new DbUser { Id = message.ChatId };
        }

        dbUser!.IsAuthorized = inviteAvailable;

        if (newUser)
        {
            await _usersRepository.AddAsync(dbUser);
        }

        await _usersRepository.SaveChangesAsync();

        return dbUser.IsAuthorized;
    }
}