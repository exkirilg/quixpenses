using Quixpenses.Common.Models;
using Quixpenses.DatabaseAccess;
using Quixpenses.Services.Users.Interfaces;

namespace Quixpenses.Services.Users;

public class UserCreationService(UnitOfWork unitOfWork) : IUserCreationService
{
    public async Task<User> CreateUserAsync(long userId)
    {
        var currency = await GetDefaultCurrency();

        var result = new User
        {
            Id = userId,
            IsAuthorized = false,
            Settings = new UserSettings { Currency = currency },
        };

        await unitOfWork.UsersRepository.AddAsync(result);
        await unitOfWork.SaveChangesAsync();

        return result;
    }

    private async Task<Currency> GetDefaultCurrency()
    {
        const string defaultCurrencyCode = "USD";
        var currency = await unitOfWork.CurrenciesRepository.TryGetByIdAsync(defaultCurrencyCode);

        if (currency is null)
        {
            throw new Exception("Default currency not found");
        }

        return currency;
    }
}