using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Data.Modules.Finance.Repositories.Interfaces;

public interface ICurrencyRepository
{
    Task<List<Currency>> GetCurrenciesAsync(string? name, string? isoCode, string? symbol);
    Task<Currency> GetCurrencyByIdAsync(Guid id);
    Task<Currency?> CreateCurrencyAsync(Currency currency);
    Task<Currency?> UpdateCurrencyAsync(Guid id, Currency currency);
    Task<Currency?> DeleteCurrencyAsync(Guid id);
}