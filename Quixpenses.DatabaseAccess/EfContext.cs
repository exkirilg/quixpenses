using Microsoft.EntityFrameworkCore;
using Quixpenses.Common.Models;
using Quixpenses.DatabaseAccess.DatabaseConfiguration;
using Quixpenses.DatabaseAccess.SeedingData;

namespace Quixpenses.DatabaseAccess;

public class EfContext(DbContextOptions<EfContext> options) : DbContext(options)
{
    public DbSet<Invite> Invites { get; init; } = default!;

    public DbSet<User> Users { get; init; } = default!;

    public DbSet<UserSettings> UsersSettings { get; init; } = default!;

    public DbSet<Currency> Currencies { get; init; } = default!;

    public DbSet<Transaction> Transactions { get; init; } = default!;

    public DbSet<Category> Categories { get; init; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureCurrencies();
        modelBuilder.ConfigureUsers();
        modelBuilder.ConfigureTransactions();
        modelBuilder.ConfigureCategories();

        modelBuilder.SeedCurrencies();
    }
}