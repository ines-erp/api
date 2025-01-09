using System.Linq.Expressions;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Data.Modules.Finance.Repositories.Concrete;

public class PSQLCurrencyRepository : ICurrencyRepository
{
    private readonly FinanceDbContext _context;

    public PSQLCurrencyRepository(FinanceDbContext context)
    {
        _context = context;
    }
    public async Task<List<Currency>> GetCurrenciesAsync(string? name, string? isoCode, string? symbol)
    {
        var currencies = _context.Currencies.AsQueryable();

        // Filter by name (case-insensitive)
        if (!string.IsNullOrWhiteSpace(name))
        {
            currencies = currencies.Where(currency => currency.Name.ToLower().Contains(name.ToLower()));
        }

        // Filter by ISO code (case-insensitive)
        if (!string.IsNullOrWhiteSpace(isoCode))
        {
            currencies = currencies.Where(currency => currency.ISOCode.ToLower().Contains(isoCode.ToLower()));
        }

        // Filter by symbol (case-insensitive)
        if (!string.IsNullOrWhiteSpace(symbol))
        {
            currencies = currencies.Where(currency => currency.Symbol.ToLower().Contains(symbol.ToLower()));
        }

        return await currencies.ToListAsync();
    }
    
    public Task<Currency> GetCurrencyByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Currency?> CreateCurrencyAsync(Currency currency)
    {
        throw new NotImplementedException();
    }

    public Task<Currency?> UpdateCurrencyAsync(Guid id, Currency currency)
    {
        throw new NotImplementedException();
    }

    public Task<Currency?> DeleteCurrencyAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}