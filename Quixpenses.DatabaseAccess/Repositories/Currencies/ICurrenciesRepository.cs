using Quixpenses.Common.Models;

namespace Quixpenses.DatabaseAccess.Repositories.Currencies;

public interface ICurrenciesRepository : IGenericRepository<Currency>
{
    Task<Currency?> TryGetByIdAsync(string id);
}