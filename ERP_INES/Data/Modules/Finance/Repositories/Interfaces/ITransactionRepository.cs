using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Data.Modules.Finance.Repositories.Interfaces;

public interface ITransactionRepository
{
    Task<List<Transaction>> GetTransactionsAsync(string? currency,
        string? sort,
        string order="asc",
        int page = 1,
        int limit = 1000
        );
    
    Task<Transaction> CreateAsync(Transaction transaction);
    Task<Transaction?> GetTransactionsByIdAsync(Guid id);
    Task<Transaction?> UpdateTransactionsAsync(Guid id, Transaction transaction);
    Task<Transaction?> DeleteTransactionsAsync(Guid id);
}