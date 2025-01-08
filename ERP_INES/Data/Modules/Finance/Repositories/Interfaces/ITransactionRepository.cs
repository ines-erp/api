using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Data.Modules.Finance.Repositories.Interfaces;

public interface ITransactionRepository
{
    Task<List<Transaction>> GetTransactionsAsync();
    Task<List<Transaction>> GetTransactionsAsync(string? currency);
    
    Task<Transaction> CreateAsync(Transaction transaction);
    Task<Transaction?> GetTransactionsByIdAsync(Guid id);
    Task<Transaction?> UpdateTransactionsAsync(Guid id, Transaction transaction);
    Task<Transaction?> DeleteTransactionsAsync(Guid id);
}