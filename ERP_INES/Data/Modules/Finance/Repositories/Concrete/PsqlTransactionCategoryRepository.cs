using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.Entities;

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
        throw new NotImplementedException();
    }

    public async Task<TransactionCategory?> GetByIdAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionCategory> CreateAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionCategory?> PutAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionCategory?> DeleteAsync()
    {
        throw new NotImplementedException();
    }
}