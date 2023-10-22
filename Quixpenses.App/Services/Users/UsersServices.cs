using Quixpenses.App.DatabaseAccess.DatabaseModels;
using Quixpenses.App.DatabaseAccess.UnitOfWork;
using Quixpenses.App.Models;
using Quixpenses.App.Services.Invites;

namespace Quixpenses.App.Services.Users;

public class UsersServices : IUsersServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInvitesServices _invitesServices;

    public UsersServices(
        IUnitOfWork unitOfWork,
        IInvitesServices invitesServices)
    {
        _unitOfWork = unitOfWork;
        _invitesServices = invitesServices;
    }

    public async Task<bool> IsAuthorizedAsync(long id)
    {
        var dbUser = await _unitOfWork.UsersRepository.TryGetByIdReadonlyAsync(id);
        return dbUser?.IsAuthorized ?? false;
    }

    public async Task<bool> TryAuthorizeUserAsync(IncomingMessage message)
    {
        var inviteAvailable = await _invitesServices.TryUseInviteAsync(message.Text);

        var dbUser = await _unitOfWork.UsersRepository.TryGetByIdAsync(message.ChatId);

        var newUser = dbUser is null;

        if (newUser)
        {
            dbUser = new DbUser { Id = message.ChatId };
        }

        dbUser!.IsAuthorized = inviteAvailable;

        if (newUser)
        {
            await _unitOfWork.UsersRepository.AddAsync(dbUser);
        }

        await _unitOfWork.SaveChangesAsync();

        return dbUser.IsAuthorized;
    }
}