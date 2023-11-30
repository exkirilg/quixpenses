using Quixpenses.Common.Models;
using Quixpenses.DatabaseAccess;
using Quixpenses.Services.Users.Interfaces;

namespace Quixpenses.Services.Users;

public class UserSettingsService(UnitOfWork unitOfWork) : IUserSettingsService
{
    public Task SetUserCurrency(User user, Currency value)
    {
        var userSettings = user.Settings;
        if (userSettings is null) throw new Exception("Unable to provide user settings");

        userSettings.Currency = value;
        return unitOfWork.SaveChangesAsync();
    }
}