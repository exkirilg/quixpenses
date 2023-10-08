using Microsoft.EntityFrameworkCore;
using Quixpenses.App.DatabaseAccess.DatabaseModels;
using Quixpenses.App.DatabaseAccess.SeedingData;

namespace Quixpenses.App.DatabaseAccess;

public class EfContext : DbContext
{
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
    }

    public DbSet<DbUser> Users { get; set; } = default!;

    public DbSet<DbCurrency> Currencies { get; set; } = default!;

    public DbSet<DbTransaction> Transactions { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedCurrencies();
    }
}