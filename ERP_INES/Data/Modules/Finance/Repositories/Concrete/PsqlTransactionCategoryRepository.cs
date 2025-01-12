using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Data.Modules.Finance.Repositories.Concrete;

public class PsqlTransactionCategoryRepository : ITransactionCategoryRespository
{
    private readonly FinanceDbContext _context;

    public PsqlTransactionCategoryRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionCategory>> GetAsync()
    {
        var categories = await _context.TransactionCategories.ToListAsync();

        return categories;
    }

    public async Task<TransactionCategory?> GetByIdAsync(Guid id)
    {
        var category = await _context.TransactionCategories.FirstOrDefaultAsync(x => x.Id == id);

        if (category is null)
            return null;

        return category;
    }

    public async Task<TransactionCategory> CreateAsync(TransactionCategory transactionCategory)
    {
        await _context.TransactionCategories.AddAsync(transactionCategory);
        await _context.SaveChangesAsync();

        return transactionCategory;
    }

    public async Task<TransactionCategory?> PutAsync(Guid id, TransactionCategory transactionCategory)
    {
        var category = await _context.TransactionCategories.FirstOrDefaultAsync(x => x.Id == id);
        if (category is null)
            return null;

        category.Name = transactionCategory.Name;
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<TransactionCategory?> DeleteAsync(Guid id)
    {
        var category = await _context.TransactionCategories.FirstOrDefaultAsync(x => x.Id == id);
        if (category is null)
            return null;

        _context.TransactionCategories.Remove(category);
        await _context.SaveChangesAsync();

        return category;
    }
}