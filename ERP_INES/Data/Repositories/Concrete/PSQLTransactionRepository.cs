using ERP_INES.Data.Repositories.Interfaces;
using ERP_INES.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Data.Repositories.Concrete;

public class PSQLTransactionRepository : ITransactionRepository
{
    private readonly FinanceDbContext _context;

    public PSQLTransactionRepository(FinanceDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Transaction>> GetTransactionsAsync()
    {
        var transactions = await _context.Transactions.ToListAsync();

        return transactions;
    }
}