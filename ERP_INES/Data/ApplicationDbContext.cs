using ERP_INES.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Transaction = System.Transactions.Transaction;

namespace ERP_INES.Data;

public class ApplicationDbContext : DbContext

{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionCategory> TransactionCategories { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<PyamentMethod> PyamentMethods { get; set; }
    public DbSet<TransactionType> TransactionTypes { get; set; }
    
    
    
}