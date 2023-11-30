using Quixpenses.Common.Models;

namespace Quixpenses.Services.Currencies.Interfaces;

public interface IGetCurrencyService
{
    Task<Currency?> TryGetCurrencyAsync(string currencyCode);
}