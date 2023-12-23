using Microsoft.EntityFrameworkCore;
using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.DatabaseAccess.DatabaseConfiguration;

public static class DatabaseConfigurationExtensions
{
    public static ModelBuilder ConfigureExpenses(this ModelBuilder builder)
    {
        builder.Entity<Expense>()
            .Property(x => x.CreatedAt)
            .HasDefaultValueSql("now()");

        return builder;
    }

    public static ModelBuilder ConfigureCurrencies(this ModelBuilder builder)
    {
        builder.Entity<Currency>()
            .HasMany<UserSettings>()
            .WithOne(x => x.Currency)
            .HasForeignKey("currency_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Currency>()
            .HasMany<Expense>()
            .WithOne(x => x.Currency)
            .HasForeignKey("currency_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        return builder;
    }

    public static ModelBuilder ConfigureUsers(this ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasOne(x => x.Settings)
            .WithOne()
            .HasForeignKey<UserSettings>(x => x.Id)
            .IsRequired();

        builder.Entity<User>()
            .HasOne(x => x.CurrentSession)
            .WithOne()
            .HasForeignKey<Session>(x => x.Id);

        builder.Entity<User>()
            .HasMany<Expense>()
            .WithOne(x => x.User)
            .HasForeignKey("user_id")
            .IsRequired();

        builder.Entity<User>()
            .HasMany<Category>()
            .WithOne(x => x.User)
            .HasForeignKey("user_id")
            .IsRequired();

        return builder;
    }

    public static ModelBuilder ConfigureUsersSessions(this ModelBuilder builder)
    {
        builder.Entity<Session>()
            .Property("commandType")
            .HasColumnName("command_type")
            .HasColumnType("text");

        builder.Entity<Session>()
            .Property("commandJson")
            .HasColumnName("command")
            .HasColumnType("jsonb");

        return builder;
    }

    public static ModelBuilder ConfigureCategories(this ModelBuilder builder)
    {
        builder.Entity<Category>()
            .HasOne<Expense>()
            .WithOne(x => x.Category)
            .HasForeignKey<Expense>("category_id")
            .OnDelete(DeleteBehavior.Restrict);

        return builder;
    }
}