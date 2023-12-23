using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.DatabaseAccess.Repositories.Currencies;

public interface ICurrenciesRepository : IGenericRepository<Currency>
{
    Task<Currency?> TryGetByIdAsync(string id);
}