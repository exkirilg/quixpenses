using Microsoft.EntityFrameworkCore;
using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.Repositories.Currencies;

public class CurrenciesRepository : GenericRepository<Currency>, ICurrenciesRepository
{
    public CurrenciesRepository(EfContext context) : base(context)
    {
    }

    public async Task<Currency?> TryGetByIdReadonlyAsync(string id)
    {
        var result = await Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }
}