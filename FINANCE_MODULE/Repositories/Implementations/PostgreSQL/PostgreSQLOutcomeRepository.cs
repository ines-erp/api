using FINANCE_MODULE.Data;
using FINANCE_MODULE.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FINANCE_MODULE.Repositories.Implementations.PostgreSQL;

public class PostgreSQLOutcomeRepository: IOutcomeRepository
{
    private readonly FinanceDbContext _context;

    public PostgreSQLOutcomeRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Outcome>> GetOutcomes()
    {
        return await _context.Outcomes.ToListAsync();
    }

    public async Task<Outcome?> GetOutcomeById(Guid id)
    {
        var outcome = await _context.Outcomes.FirstOrDefaultAsync(outcome => outcome.Id == id);

        if (outcome is null)
            return null;
        
        return outcome;
    }

    public async Task<Outcome> CreateOutcome(Outcome outcome)
    {
        await _context.Outcomes.AddAsync(outcome);
        await _context.SaveChangesAsync();
        return outcome;
    }

    public async Task<Outcome?> UpdateOutcome(Guid id, Outcome outcome)
    {
        var existingOutcome = await _context.Outcomes.FirstOrDefaultAsync(outcome => outcome.Id == id);
        if (existingOutcome is null)
            return null;
        
        existingOutcome.Name = outcome.Name;
        existingOutcome.Description = outcome.Description;
        existingOutcome.Date = outcome.Date;
        existingOutcome.Amount = outcome.Amount;
        existingOutcome.Currency = outcome.Currency;
        existingOutcome.OutcomeMethod = outcome.OutcomeMethod;
        existingOutcome.OutcomeMethodDescription = outcome.OutcomeMethodDescription;
        existingOutcome.Beneficiary = outcome.Beneficiary;
        existingOutcome.TypeOfOutcome = outcome.TypeOfOutcome;

        await _context.SaveChangesAsync();
        
        return existingOutcome;
    }

    public async Task<Outcome?> DeleteOutcome(Guid id)
    {
        var existingOutcome = await _context.Outcomes.FirstOrDefaultAsync(outcome => outcome.Id == id);

        if (existingOutcome is null)
            return null;
        
        _context.Outcomes.Remove(existingOutcome);
        await _context.SaveChangesAsync();
        return existingOutcome;
    }
}