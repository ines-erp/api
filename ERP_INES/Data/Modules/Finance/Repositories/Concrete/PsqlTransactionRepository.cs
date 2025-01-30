using System.Reflection;
using AutoMapper;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Data.Modules.Finance.Repositories.Concrete;

public class PsqlTransactionRepository : ITransactionRepository
{
    private readonly FinanceDbContext _context;

    public PsqlTransactionRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transaction>> GetTransactionsAsync(
        string? currency,
        string? sort,
        string order = "asc",
        int page = 1,
        int limit = 1000
        )
    {
        var transactions = _context.Transactions
            .Include("PaymentMethod")
            .Include("TransactionCategory")
            .Include("TransactionType")
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(currency))
        {
            transactions = transactions
                .Where(x => x.PaymentMethod.ISOCurrencySymbol == currency);
        }

        if (!string.IsNullOrWhiteSpace(sort))
        {
            switch (sort.ToLower())
            {
                case "name":
                    transactions = order == "asc" ? transactions.OrderBy(tr => tr.Name) : transactions.OrderByDescending(tr => tr.Name);
                    break;
                case "currency":
                    transactions = order == "asc" ? transactions.OrderBy(tr => tr.PaymentMethod.ISOCurrencySymbol) : transactions.OrderByDescending(tr => tr.PaymentMethod.ISOCurrencySymbol);
                    break;
                case "amount":
                    transactions = order == "asc" ? transactions.OrderBy(tr => tr.Amount) : transactions.OrderByDescending(tr => tr.Amount);
                    break;
                default:
                    transactions = order == "asc"
                        ? transactions.OrderBy(tr => tr.CreatedAt)
                        : transactions.OrderByDescending(tr => tr.CreatedAt);
                    break;
            }
        }

        // Pagination
        if (limit != -1)
        {
            var skipResults = (page - 1) * limit;
            transactions = transactions.Skip(skipResults).Take(limit);
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