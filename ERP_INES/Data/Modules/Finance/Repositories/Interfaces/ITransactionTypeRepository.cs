using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Data.Modules.Finance.Repositories.Interfaces;

public interface ITransactionTypeRepository
{
    Task<List<TransactionType>> GetAsync();
    Task<TransactionType?> GetByIdAsync();
    Task<TransactionType> CreateAsync();
    Task<TransactionType?> PutAsync();
    Task<TransactionType?> DeleteAsync();
}