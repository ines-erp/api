using FINANCE_MODULE.Data.Models.Entities;

namespace FINANCE_MODULE.Repositories.Implementations.PostgreSQL;

public class PostgreSQLOutcomeRepository: IOutcomeRepository
{
    public Task<List<Outcome>> GetOutcomes()
    {
        throw new NotImplementedException();
    }

    public Task<Outcome?> GetOutcomeById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Outcome> CreateOutcome(Outcome Outcome)
    {
        throw new NotImplementedException();
    }

    public Task<Outcome?> UpdateOutcome(Guid id, Outcome Outcome)
    {
        throw new NotImplementedException();
    }

    public Task<Outcome?> DeleteOutcome(Guid id)
    {
        throw new NotImplementedException();
    }
}