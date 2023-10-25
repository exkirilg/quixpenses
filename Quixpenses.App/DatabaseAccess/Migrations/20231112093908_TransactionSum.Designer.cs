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
    [Migration("20231112093908_TransactionSum")]
    partial class TransactionSum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Quixpenses.App.DatabaseAccess.DatabaseModels.DbCurrency", b =>
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

            modelBuilder.Entity("Quixpenses.App.DatabaseAccess.DatabaseModels.DbInvite", b =>
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

            modelBuilder.Entity("Quixpenses.App.DatabaseAccess.DatabaseModels.DbTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

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

            modelBuilder.Entity("Quixpenses.App.DatabaseAccess.DatabaseModels.DbUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsAuthorized")
                        .HasColumnType("boolean")
                        .HasColumnName("is_authorized");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Quixpenses.App.DatabaseAccess.DatabaseModels.DbTransaction", b =>
                {
                    b.HasOne("Quixpenses.App.DatabaseAccess.DatabaseModels.DbCurrency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_transactions_currencies_currency_id");

                    b.HasOne("Quixpenses.App.DatabaseAccess.DatabaseModels.DbUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_transactions_users_user_id");

                    b.Navigation("Currency");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
