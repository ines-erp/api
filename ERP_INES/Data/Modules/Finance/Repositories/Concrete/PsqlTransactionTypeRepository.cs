using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Data.Modules.Finance.Repositories.Concrete;

public class PsqlTransactionTypesRepository : ITransactionTypeRepository
{
    private readonly FinanceDbContext _context;

    public PsqlTransactionTypesRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionType>> GetAsync()
    {
        var types = await _context.TransactionTypes.ToListAsync();

        return types;
    }

    public async Task<TransactionType?> GetByIdAsync(Guid id)
    {
        var type = await _context.TransactionTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (type is null)
            return null;

        return type;
    }

    public async Task<TransactionType> CreateAsync(TransactionType transactionType)
    {
        await _context.TransactionTypes.AddAsync(transactionType);
        await _context.SaveChangesAsync();

        return transactionType;
    }

    public async Task<TransactionType?> PutAsync(Guid id, TransactionType transactionType)
    {
        var type = await _context.TransactionTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (type is null)
            return null;

        type.Name = transactionType.Name;
        await _context.SaveChangesAsync();

        return type;
    }

    public async Task<TransactionType?> DeleteAsync(Guid id)
    {
        var type = await _context.TransactionTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (type is null)
            return null;

        _context.TransactionTypes.Remove(type);
        await _context.SaveChangesAsync();

        return type;
    }
}