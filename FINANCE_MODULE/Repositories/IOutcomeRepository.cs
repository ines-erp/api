using FINANCE_MODULE.Data.Models.Entities;

namespace FINANCE_MODULE.Repositories;

public interface IOutcomeRepository
{
    Task<List<Outcome>> GetOutcomes();
    Task<Outcome?> GetOutcomeById(Guid id);
    Task<Outcome> CreateOutcome(Outcome Outcome);
    Task<Outcome?> UpdateOutcome(Guid id, Outcome Outcome);
    Task<Outcome?> DeleteOutcome(Guid id);
}