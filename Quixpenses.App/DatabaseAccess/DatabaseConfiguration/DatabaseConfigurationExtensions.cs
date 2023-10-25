using Microsoft.EntityFrameworkCore;
using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.DatabaseConfiguration;

public static class DatabaseConfigurationExtensions
{
    public static void ConfigureTransactions(this ModelBuilder builder)
    {
        builder.Entity<Transaction>().Property(x => x.CreatedAt).HasDefaultValueSql("now()");
    }
}