using Microsoft.EntityFrameworkCore;
using Quixpenses.Common.Models;

namespace Quixpenses.DatabaseAccess.DatabaseConfiguration;

public static class DatabaseConfigurationExtensions
{
    public static void ConfigureTransactions(this ModelBuilder builder)
    {
        builder.Entity<Transaction>()
            .Property(x => x.CreatedAt)
            .HasDefaultValueSql("now()");
    }

    public static void ConfigureCurrencies(this ModelBuilder builder)
    {
        builder.Entity<Currency>()
            .HasMany<UserSettings>()
            .WithOne(x => x.Currency)
            .HasForeignKey("currency_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Currency>()
            .HasMany<Transaction>()
            .WithOne(x => x.Currency)
            .HasForeignKey("currency_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }

    public static void ConfigureUsers(this ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasOne(x => x.Settings)
            .WithOne()
            .HasForeignKey<UserSettings>(x => x.Id)
            .IsRequired();

        builder.Entity<User>()
            .HasMany<Transaction>()
            .WithOne(x => x.User)
            .HasForeignKey("user_id")
            .IsRequired();

        builder.Entity<User>()
            .HasMany<Category>()
            .WithOne(x => x.User)
            .HasForeignKey("user_id")
            .IsRequired();
    }

    public static void ConfigureCategories(this ModelBuilder builder)
    {
        builder.Entity<Category>()
            .HasOne<Transaction>()
            .WithOne(x => x.Category)
            .HasForeignKey<Transaction>("category_id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}