using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.DatabaseAccess.Repositories.Currencies;

public interface ICurrenciesRepository : IGenericRepository<Currency>
{
    Task<Currency?> TryGetByIdReadonlyAsync(string id);
}