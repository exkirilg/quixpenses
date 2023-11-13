using Microsoft.EntityFrameworkCore;
using Quixpenses.App.DatabaseAccess.DatabaseConfiguration;
using Quixpenses.App.DatabaseAccess.SeedingData;
using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess;

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
    }
}