using System.Globalization;
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
    
    public async Task<Currency> GetCurrencyByIdAsync(Guid id)
    {
        var currency = await _context.Currencies.FirstOrDefaultAsync(currency => currency.Id == id);

        if (currency is null)
            return null;
        
        return currency;
    }

    public async Task<Currency?> CreateCurrencyAsync(string regionCode)
    {
        var regionInfo = new RegionInfo(regionCode);
        var currency = new Currency()
        {
            Id = Guid.NewGuid(),
            Name = regionInfo.CurrencyEnglishName,
            Symbol =  regionInfo.CurrencySymbol,
            ISOCode = regionInfo.ISOCurrencySymbol
        };
        
        await _context.Currencies.AddAsync(currency);
        await _context.SaveChangesAsync();

        return currency;
    }

    public async Task<Currency?> UpdateCurrencyAsync(Guid id, Currency currency)
    {
        var existingCurrency = await _context.Currencies.FirstOrDefaultAsync(c => c.Id == id);

        if (existingCurrency is null)
            return null;

        existingCurrency.Name = currency.Name;

        await _context.SaveChangesAsync();
        return existingCurrency;
    }

    public Task<Currency?> DeleteCurrencyAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}