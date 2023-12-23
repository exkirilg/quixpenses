using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.Services.Users.Interfaces;

public interface IUserSettingsService
{
    Task SetUserCurrency(User user, Currency value);
}