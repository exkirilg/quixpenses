using Quixpenses.Common.Models;

namespace Quixpenses.DatabaseAccess.Repositories.Currencies;

public class CurrenciesRepository(EfContext context) : GenericRepository<Currency>(context), ICurrenciesRepository
{
    public async Task<Currency?> TryGetByIdAsync(string id)
    {
        return await Context.Currencies.FindAsync(id);
    }
}