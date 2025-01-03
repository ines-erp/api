using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Data.Modules.Finance.Repositories.Concrete;

public class PSQLTransactionRepository : ITransactionRepository
{
    private readonly FinanceDbContext _context;

    public PSQLTransactionRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transaction>> GetTransactionsAsync()
    {
        var transactions = await _context.Transactions
            .Include("Currency")
            .Include("PaymentMethod")
            .Include("TransactionCategory")
            .Include("TransactionType")
            .ToListAsync();

        return transactions;
    }

    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();

        return transaction;
    }
}