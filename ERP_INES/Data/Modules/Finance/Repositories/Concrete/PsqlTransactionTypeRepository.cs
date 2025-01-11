using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Data.Modules.Finance.Repositories.Concrete;

public class PsqlTransactionTypeRepository : ITransactionTypeRepository
{
    private readonly FinanceDbContext _context;

    public PsqlTransactionTypeRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionType>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionType?> GetByIdAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionType> CreateAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionType?> PutAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionType?> DeleteAsync()
    {
        throw new NotImplementedException();
    }
}