﻿// <auto-generated />
using System;
using ERP_INES.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERP_INES.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    [Migration("20250102192721_seeding some data")]
    partial class seedingsomedata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ERP_INES.Domain.Entities.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7df7cddf-471b-4e17-bc59-70b0ff0a144d"),
                            Name = "Euro",
                            Symbol = "€"
                        },
                        new
                        {
                            Id = new Guid("10f35f9e-7810-44b7-be37-a9d7cd6ef5f8"),
                            Name = "Brazilian Real",
                            Symbol = "R$"
                        });
                });

            modelBuilder.Entity("ERP_INES.Domain.Entities.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1d69c5c3-9887-47e3-a07d-6cffbb5051f5"),
                            Description = "Paid by cash",
                            Name = "Cash"
                        },
                        new
                        {
                            Id = new Guid("a15541a5-335e-4cd9-9c2e-7240fd9a006f"),
                            Description = "Transferred to bank account",
                            Name = "Bank transfer"
                        });
                });

            modelBuilder.Entity("ERP_INES.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaidBy")
                        .HasColumnType("text");

                    b.Property<Guid>("PaymentMethodId")
                        .HasColumnType("uuid");

                    b.Property<string>("RecievedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("TransactionCategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("TransactionCategoryId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ERP_INES.Domain.Entities.TransactionCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TransactionCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e25116d5-911d-4d3c-9a36-1edee0398de7"),
                            Name = "Bills"
                        },
                        new
                        {
                            Id = new Guid("7e9e46e8-4a54-41f2-89cb-8448960971ff"),
                            Name = "Assets acquisition"
                        });
                });

            modelBuilder.Entity("ERP_INES.Domain.Entities.TransactionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("92d6e7b8-a4e0-43a1-b0d7-50921e851cc4"),
                            Name = "Income"
                        },
                        new
                        {
                            Id = new Guid("fd5e3535-5a7c-4294-abde-49e869d77957"),
                            Name = "Outcome"
                        });
                });

            modelBuilder.Entity("ERP_INES.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("ERP_INES.Domain.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP_INES.Domain.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP_INES.Domain.Entities.TransactionCategory", "TransactionCategory")
                        .WithMany()
                        .HasForeignKey("TransactionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("PaymentMethod");

                    b.Navigation("TransactionCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
