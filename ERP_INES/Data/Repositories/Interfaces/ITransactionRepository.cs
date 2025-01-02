using ERP_INES.Domain.Entities;

namespace ERP_INES.Data.Repositories.Interfaces;

public interface ITransactionRepository
{
    Task<List<Transaction>> GetTransactionsAsync();
}