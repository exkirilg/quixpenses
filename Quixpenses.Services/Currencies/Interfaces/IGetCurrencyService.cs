using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.Services.Currencies.Interfaces;

public interface IGetCurrencyService
{
    Task<Currency?> TryGetCurrencyAsync(string currencyCode);
}