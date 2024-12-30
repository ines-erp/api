using FINANCE_MODULE.Data;
using FINANCE_MODULE.Data.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FINANCE_MODULE.Repositories.Implementations.PostgreSQL;

public class PostgreSQLIncomeRepository : IIncomeRepository
{
    private readonly FinanceDbContext _context;

    public PostgreSQLIncomeRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Income>> GetIncomes()
    {
        return await _context.Incomes.ToListAsync();
    }

    public async Task<Income?> GetIncomeById(Guid id)
    {
        var existingIncome = await _context.Incomes.FirstOrDefaultAsync(income => income.Id == id);

        if (existingIncome == null)
        {
            return null;
        }

        return existingIncome;
    }

    public async Task<Income> CreateIncome(Income income)
    {
        await _context.Incomes.AddAsync(income);
        await _context.SaveChangesAsync();

        return income;
    }

    public async Task<Income?> UpdateIncome(Guid id, Income income)
    {
        var existingIncome = await _context.Incomes.FirstOrDefaultAsync(i => i.Id == id);
        if (existingIncome is null)
            return null;

        existingIncome.Name = income.Name;
        existingIncome.Description = income.Description;
        existingIncome.Date = income.Date;
        existingIncome.Amount = income.Amount;
        existingIncome.Currency = income.Currency;
        existingIncome.IncomeMethod = income.IncomeMethod;
        existingIncome.IncomeMethodDescription = income.IncomeMethodDescription;
        existingIncome.PaidBy = income.PaidBy;
        existingIncome.TypeOfIncome = income.TypeOfIncome;

        await _context.SaveChangesAsync();

        return existingIncome;
    }

    public async Task<Income?> DeleteIncome(Guid id)
    {
        var existingIncome = await _context.Incomes.FirstOrDefaultAsync(income => income.Id == id);

        if (existingIncome is null)
            return null;

        _context.Incomes.Remove(existingIncome);
        await _context.SaveChangesAsync();
        return existingIncome;
    }
}