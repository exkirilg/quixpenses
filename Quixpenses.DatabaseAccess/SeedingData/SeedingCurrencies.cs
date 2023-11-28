using Microsoft.EntityFrameworkCore;
using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.DatabaseAccess.SeedingData;

public static class SeedingCurrencies
{
    public static void SeedCurrencies(this ModelBuilder builder)
    {
        builder.Entity<Currency>().HasData(
            new Currency { Id = "USD", FractionDigits = 2 },
            new Currency { Id = "EUR", FractionDigits = 2 });
    }
}