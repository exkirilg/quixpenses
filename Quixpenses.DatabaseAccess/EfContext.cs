using Microsoft.EntityFrameworkCore;
using Quixpenses.DatabaseAccess.DatabaseConfiguration;
using Quixpenses.DatabaseAccess.DatabaseModels;
using Quixpenses.DatabaseAccess.SeedingData;

namespace Quixpenses.DatabaseAccess;

public class EfContext(
        DbContextOptions<EfContext> options)
    : DbContext(options)
{
    public DbSet<Invite> Invites { get; set; } = default!;

    public DbSet<User> Users { get; set; } = default!;

    public DbSet<UserSettings> UsersSettings { get; set; } = default!;

    public DbSet<Currency> Currencies { get; set; } = default!;

    public DbSet<Transaction> Transactions { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedCurrencies();
        modelBuilder.ConfigureTransactions();
        modelBuilder.ConfigureUserSettings();
    }
}