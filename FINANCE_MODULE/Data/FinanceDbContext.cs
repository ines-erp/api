using Microsoft.EntityFrameworkCore;

namespace FINANCE_MODULE.Data;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions options) : base(options)
    {
    }
    
    //Below here we could define our tables
}