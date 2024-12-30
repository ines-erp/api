using FINANCE_MODULE.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FINANCE_MODULE.Data;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Income> Incomes { get; set; }
    public DbSet<Outcome> Outcomes { get; set; }
}