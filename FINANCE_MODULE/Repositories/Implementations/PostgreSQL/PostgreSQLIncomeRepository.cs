using FINANCE_MODULE.Data;
using FINANCE_MODULE.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FINANCE_MODULE.Repositories.Implementations.PostgreSQL;

public class PostgreSQLIncomeRepository : IIncomeRepository
{
    private readonly FinanceDbContext _context;

    public PostgreSQLIncomeRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Income>> GetAllIncomes()
    {
        return await _context.Incomes.ToListAsync();
    }
}