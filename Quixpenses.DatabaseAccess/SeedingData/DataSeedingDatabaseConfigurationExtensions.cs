using Microsoft.EntityFrameworkCore;
using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.DatabaseAccess.SeedingData;

public static class DataSeedingDatabaseConfigurationExtensions
{
    public static ModelBuilder SeedCurrencies(this ModelBuilder builder)
    {
        builder.Entity<Currency>().HasData(
            new Currency { Id = "USD", FractionDigits = 2 },
            new Currency { Id = "EUR", FractionDigits = 2 });

        return builder;
    }
}