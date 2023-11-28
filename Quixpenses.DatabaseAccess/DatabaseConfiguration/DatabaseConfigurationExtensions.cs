using Microsoft.EntityFrameworkCore;
using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.DatabaseAccess.DatabaseConfiguration;

public static class DatabaseConfigurationExtensions
{
    public static void ConfigureTransactions(this ModelBuilder builder)
    {
        builder.Entity<Transaction>().Property(x => x.CreatedAt).HasDefaultValueSql("now()");
    }

    public static void ConfigureUserSettings(this ModelBuilder builder)
    {
        builder.Entity<UserSettings>().Property(x => x.CurrencyId).HasDefaultValue("USD");
    }
}