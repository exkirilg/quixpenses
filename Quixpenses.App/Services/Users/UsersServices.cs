using Quixpenses.App.DatabaseAccess.UnitOfWork;
using Quixpenses.App.Guards;
using Quixpenses.App.Models;
using Quixpenses.App.Services.Invites;

namespace Quixpenses.App.Services.Users;

public class UsersServices(
        IUnitOfWork unitOfWork,
        IInvitesServices invitesServices)
    : IUsersServices
{
    public async Task<User?> TryGetUserReadonlyAsync(long id)
    {
        var result = await unitOfWork.UsersRepository.TryGetByIdReadonlyAsync(id);
        return result;
    }

    public async Task<bool> TryAuthorizeUserAsync(IncomingMessage message)
    {
        var inviteAvailable = await invitesServices.TryUseInviteAsync(message.Text);

        var dbUser = await unitOfWork.UsersRepository.TryGetByIdAsync(message.ChatId);

        var newUser = dbUser is null;

        if (newUser)
        {
            dbUser = new User { Id = message.ChatId };
        }

        dbUser!.IsAuthorized = inviteAvailable;

        if (newUser)
        {
            dbUser.UserSettings = new UserSettings();
            await unitOfWork.UsersRepository.AddAsync(dbUser);
        }

        await unitOfWork.SaveChangesAsync();

        return dbUser.IsAuthorized;
    }

    public async Task SetUserCurrencyAsync(User user, string currencyCode)
    {
        var userSettings = await unitOfWork.UsersSettingsRepository.GetByIdAsync(user.UserSettingsId);

        var currency = await unitOfWork.CurrenciesRepository.TryGetByIdReadonlyAsync(currencyCode);
        Guard.AgainstCurrencyNotFound(currency);

        userSettings.CurrencyId = currencyCode;

        await unitOfWork.SaveChangesAsync();
    }
}