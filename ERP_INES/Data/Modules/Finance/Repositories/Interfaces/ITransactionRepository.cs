using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Data.Modules.Finance.Repositories.Interfaces;

public interface ITransactionRepository
{
    Task<List<Transaction>> GetTransactionsAsync();

    Task<Transaction> CreateAsync(Transaction transaction);
}