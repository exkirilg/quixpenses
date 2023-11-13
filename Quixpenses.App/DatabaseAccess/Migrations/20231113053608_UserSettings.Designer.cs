﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Quixpenses.App.DatabaseAccess;

#nullable disable

namespace Quixpenses.App.DatabaseAccess.Migrations
{
    [DbContext(typeof(EfContext))]
    [Migration("20231113053608_UserSettings")]
    partial class UserSettings
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Quixpenses.App.Models.Currency", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("FractionDigits")
                        .HasColumnType("integer")
                        .HasColumnName("fraction_digits");

                    b.HasKey("Id")
                        .HasName("pk_currencies");

                    b.ToTable("currencies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "USD",
                            FractionDigits = 2
                        },
                        new
                        {
                            Id = "EUR",
                            FractionDigits = 2
                        });
                });

            modelBuilder.Entity("Quixpenses.App.Models.Invite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Available")
                        .HasColumnType("integer")
                        .HasColumnName("available");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expires_at");

                    b.Property<int>("Used")
                        .HasColumnType("integer")
                        .HasColumnName("used");

                    b.HasKey("Id")
                        .HasName("pk_invites");

                    b.ToTable("invites", (string)null);
                });

            modelBuilder.Entity("Quixpenses.App.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("CurrencyId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("currency_id");

                    b.Property<int>("Sum")
                        .HasColumnType("integer")
                        .HasColumnName("sum");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_transactions");

                    b.HasIndex("CurrencyId")
                        .HasDatabaseName("ix_transactions_currency_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_transactions_user_id");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("Quixpenses.App.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsAuthorized")
                        .HasColumnType("boolean")
                        .HasColumnName("is_authorized");

                    b.Property<Guid>("UserSettingsId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_settings_id");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("UserSettingsId")
                        .HasDatabaseName("ix_users_user_settings_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Quixpenses.App.Models.UserSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CurrencyId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("currency_id");

                    b.HasKey("Id")
                        .HasName("pk_users_settings");

                    b.HasIndex("CurrencyId")
                        .HasDatabaseName("ix_users_settings_currency_id");

                    b.ToTable("users_settings", (string)null);
                });

            modelBuilder.Entity("Quixpenses.App.Models.Transaction", b =>
                {
                    b.HasOne("Quixpenses.App.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_transactions_currencies_currency_id");

                    b.HasOne("Quixpenses.App.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_transactions_users_user_id");

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Quixpenses.App.Models.User", b =>
                {
                    b.HasOne("Quixpenses.App.Models.UserSettings", "UserSettings")
                        .WithMany()
                        .HasForeignKey("UserSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_users_settings_user_settings_id");

                    b.Navigation("UserSettings");
                });

            modelBuilder.Entity("Quixpenses.App.Models.UserSettings", b =>
                {
                    b.HasOne("Quixpenses.App.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_settings_currencies_currency_id");

                    b.Navigation("Currency");
                });
#pragma warning restore 612, 618
        }
    }
}