using Microsoft.EntityFrameworkCore;
using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.Repositories.Currencies;

public class CurrenciesRepository(
        EfContext context)
    : GenericRepository<Currency>(context), ICurrenciesRepository
{
    public async Task<Currency?> TryGetByIdReadonlyAsync(string id)
    {
        var result = await Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }
}