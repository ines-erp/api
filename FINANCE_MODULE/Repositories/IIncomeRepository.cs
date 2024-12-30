using FINANCE_MODULE.Data.Models.Entities;

namespace FINANCE_MODULE.Repositories;

public interface IIncomeRepository
{
    //list all methods that will be implemented on the concrete class
    Task<List<Income>> GetIncomes();
    Task<Income?> GetIncomeById(Guid id);
    Task<Income> CreateIncome(Income income);
    Task<Income?> UpdateIncome(Guid id, Income income);
    Task<Income?> DeleteIncome(Guid id);
}