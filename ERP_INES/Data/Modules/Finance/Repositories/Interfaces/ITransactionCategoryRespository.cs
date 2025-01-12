using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Data.Modules.Finance.Repositories.Interfaces;

public interface ITransactionCategoryRespository
{
    Task<List<TransactionCategory>> GetAsync();
    Task<TransactionCategory?> GetByIdAsync(Guid id);
    Task<TransactionCategory> CreateAsync(TransactionCategory transactionCategory);
    Task<TransactionCategory?> PutAsync(Guid id, TransactionCategory transactionCategory);
    Task<TransactionCategory?> DeleteAsync(Guid id);
}