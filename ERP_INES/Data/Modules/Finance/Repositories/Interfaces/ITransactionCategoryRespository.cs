using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Data.Modules.Finance.Repositories.Interfaces;

public interface ITransactionCategoryRespository
{
    Task<List<TransactionCategory>> GetAsync();
    Task<TransactionCategory?> GetByIdAsync();
    Task<TransactionCategory> CreateAsync();
    Task<TransactionCategory?> PutAsync();
    Task<TransactionCategory?> DeleteAsync();
}