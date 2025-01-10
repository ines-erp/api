using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Data.Modules.Finance;

public class FinanceDbContext : DbContext

{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
    {
    }

    public DbSet<TransactionType> TransactionTypes { get; set; }
    public DbSet<TransactionCategory> TransactionCategories { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Transaction> Transactions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var transactionTypes = new List<TransactionType>
        {
            new TransactionType
            {
                Id = Guid.Parse("92D6E7B8-A4E0-43A1-B0D7-50921E851CC4"),
                Name = "Income"
            },
            new TransactionType
            {
                Id = Guid.Parse("FD5E3535-5A7C-4294-ABDE-49E869D77957"),
                Name = "Outcome"
            }
        };

        var transactionCategories = new List<TransactionCategory>
        {
            new TransactionCategory
            {
                Id = Guid.Parse("E25116D5-911D-4D3C-9A36-1EDEE0398DE7"),
                Name = "Bills"
            },
            new TransactionCategory
            {
                Id = Guid.Parse("7E9E46E8-4A54-41F2-89CB-8448960971FF"),
                Name = "Assets acquisition"
            }
        };

        var paymentMethods = new List<PaymentMethod>
        {
            new PaymentMethod
            {
                Id = Guid.Parse("1D69C5C3-9887-47E3-A07D-6CFFBB5051F5"),
                Type = "Card",
                Name = "Debit card 4504",
                Description = "The VISA card with end 4504 on the Santander account in the name of the company",
                ISOCurrencySymbol = "EUR"
            },
            new PaymentMethod
            {
                Id = Guid.Parse("A15541A5-335E-4CD9-9C2E-7240FD9A006F"),
                Type = "Bank transfer",
                Name = "Santander",
                Description = "Transferred to Santander bank account",
                ISOCurrencySymbol = "EUR"
            }
        };

        modelBuilder.Entity<TransactionType>().HasData(transactionTypes);
        modelBuilder.Entity<TransactionCategory>().HasData(transactionCategories);
        modelBuilder.Entity<PaymentMethod>().HasData(paymentMethods);
    }
}