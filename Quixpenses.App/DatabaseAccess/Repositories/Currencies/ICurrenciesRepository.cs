using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.Repositories.Currencies;

public interface ICurrenciesRepository : IGenericRepository<Currency>
{
    Task<Currency?> TryGetByIdReadonlyAsync(string id);
}