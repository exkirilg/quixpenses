using Quixpenses.Common.Models.DbModels;
using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.Services.Currencies.Interfaces;

namespace Quixpenses.Services.Currencies;

public class GetCurrencyService(IUnitOfWork unitOfWork) : IGetCurrencyService
{
    public Task<Currency?> TryGetCurrencyAsync(string currencyCode)
    {
        return unitOfWork.CurrenciesRepository.TryGetByIdAsync(currencyCode);
    }
}