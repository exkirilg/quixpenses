using Microsoft.EntityFrameworkCore;
using Quixpenses.Common.Models;

namespace Quixpenses.DatabaseAccess.SeedingData;

public static class DataSeedingDatabaseConfigurationExtensions
{
    public static void SeedCurrencies(this ModelBuilder builder)
    {
        builder.Entity<Currency>().HasData(
            new Currency { Id = "USD", FractionDigits = 2 },
            new Currency { Id = "EUR", FractionDigits = 2 });
    }
}