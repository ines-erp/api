using FINANCE_MODULE.Data.Models.Entities;

namespace FINANCE_MODULE.Repositories;

public interface IIncomeRepository
{
    //list all methods that will be implemented on the concrete class
    Task<List<Income>> GetAllIncomes();
}