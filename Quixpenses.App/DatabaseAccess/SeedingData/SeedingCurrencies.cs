using Microsoft.EntityFrameworkCore;
using Quixpenses.App.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.DatabaseAccess.SeedingData;

public static class SeedingCurrencies
{
    public static void SeedCurrencies(this ModelBuilder builder)
    {
        builder.Entity<DbCurrency>().HasData(
            new DbCurrency { Id = "USD", FractionDigits = 2 },
            new DbCurrency { Id = "EUR", FractionDigits = 2 });
    }
}