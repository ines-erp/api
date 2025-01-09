using System.Reflection;
using AutoMapper;
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
            .Include("PaymentMethod")
            .Include("PaymentMethod.Currency")
            .Include("TransactionCategory")
            .Include("TransactionType")
            .ToListAsync();

        return transactions;
    }

    public async Task<List<Transaction>> GetTransactionsAsync(string? currency)
    {
        var transactions = _context.Transactions
            .Include("PaymentMethod")
            .Include("PaymentMethod.Currency")
            .Include("TransactionCategory")
            .Include("TransactionType")
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(currency))
        {
            transactions = transactions
                .Where(x => x.PaymentMethod.Currency.ISOCode == currency);
        }

        return await transactions.ToListAsync();
    }

    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();

        //TODO: check if is possible to get all relate object to return that.
        return transaction;
    }

    public async Task<Transaction?> GetTransactionsByIdAsync(Guid id)
    {
        var existingTransaction = await _context.Transactions
            .Include("PaymentMethod")
            .Include("PaymentMethod.Currency")
            .Include("TransactionCategory")
            .Include("TransactionType")
            .FirstOrDefaultAsync(x => x.Id == id);

        if (existingTransaction == null)
            return null;

        return existingTransaction;
    }

    public async Task<Transaction?> UpdateTransactionsAsync(Guid id, Transaction transaction)
    {
        var existingTransaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
        if (existingTransaction == null)
            return null;

        existingTransaction.Name = transaction.Name;
        existingTransaction.Amount = transaction.Amount;
        existingTransaction.Description = transaction.Description;
        existingTransaction.Date = transaction.Date;
        existingTransaction.PaidBy = transaction.PaidBy;
        existingTransaction.ReceivedBy = transaction.ReceivedBy;
        existingTransaction.PaymentMethodId = transaction.PaymentMethodId;
        existingTransaction.TransactionCategoryId = transaction.TransactionCategoryId;
        existingTransaction.TransactionTypeId = transaction.TransactionTypeId;
        existingTransaction.UpdatedAt = DateTime.Now.ToUniversalTime();

        await _context.SaveChangesAsync();

        return existingTransaction;
    }

    public async Task<Transaction?> DeleteTransactionsAsync(Guid id)
    {
        var existingTransaction = await _context.Transactions
            .FirstOrDefaultAsync(x => x.Id == id);

        if (existingTransaction == null)
            return null;

        _context.Transactions.Remove(existingTransaction);
        await _context.SaveChangesAsync();

        return existingTransaction;
    }
}