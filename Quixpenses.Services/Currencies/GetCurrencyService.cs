using Quixpenses.Common.Models;
using Quixpenses.DatabaseAccess;
using Quixpenses.Services.Currencies.Interfaces;

namespace Quixpenses.Services.Currencies;

public class GetCurrencyService(UnitOfWork unitOfWork) : IGetCurrencyService
{
    public Task<Currency?> TryGetCurrencyAsync(string currencyCode)
    {
        return unitOfWork.CurrenciesRepository.TryGetByIdAsync(currencyCode);
    }
}