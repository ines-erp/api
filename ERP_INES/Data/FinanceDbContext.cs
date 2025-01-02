using ERP_INES.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Data;

public class FinanceDbContext : DbContext

{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
    {
    }

    public DbSet<Currency> Currencies { get; set; }
    public DbSet<TransactionType> TransactionTypes { get; set; }
    public DbSet<TransactionCategory> TransactionCategories { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Transaction> Transactions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var currencies = new List<Currency>
        {
            new Currency
            {
                Id = Guid.NewGuid(),
                Name = "Euro",
                Symbol = "€"
            },
            new Currency
            {
                Id = Guid.NewGuid(),
                Name = "Brazilian Real",
                Symbol = "R$"
            }
        };

        var transactionTypes = new List<TransactionType>
        {
            new TransactionType
            {
                Id = Guid.NewGuid(),
                Name = "Income"
            },
            new TransactionType
            {
                Id = Guid.NewGuid(),
                Name = "Outcome"
            }
        };

        var transactionCategories = new List<TransactionCategory>
        {
            new TransactionCategory
            {
                Id = Guid.NewGuid(),
                Name = "Bills"
            },
            new TransactionCategory
            {
                Id = Guid.NewGuid(),
                Name = "Assets acquisition"
            }
        };

        var paymentMethods = new List<PaymentMethod>
        {
            new PaymentMethod
            {
                Id = Guid.NewGuid(),
                Name = "Cash",
                Description = "Paid by cash"
            },
            new PaymentMethod
            {
                Id = Guid.NewGuid(),
                Name = "Bank transfer",
                Description = "Transferred to bank account"
            }
        };

        modelBuilder.Entity<Currency>().HasData(currencies);
        modelBuilder.Entity<TransactionType>().HasData(transactionTypes);
        modelBuilder.Entity<TransactionCategory>().HasData(transactionCategories);
        modelBuilder.Entity<PaymentMethod>().HasData(paymentMethods);
    }
}