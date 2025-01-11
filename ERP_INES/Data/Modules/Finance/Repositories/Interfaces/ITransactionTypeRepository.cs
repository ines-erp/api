using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Data.Modules.Finance.Repositories.Interfaces;

public interface ITransactionTypeRepository
{
    Task<List<TransactionType>> GetAsync();
    Task<TransactionType?> GetByIdAsync(Guid id);
    Task<TransactionType> CreateAsync(TransactionType transactionType);
    Task<TransactionType?> PutAsync(Guid id, TransactionType transactionType);
    Task<TransactionType?> DeleteAsync(Guid id);
}