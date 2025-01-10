using System.Globalization;
using ERP_INES.Domain.Modules.Finance.DTOs;

namespace ERP_INES.Helpers;

public class CurrencyHelper
{
    public static CurrencyDto? GetCurrencyInfoByIsoCode(string localSymbol)
    {
        var cultureInfo =  CultureInfo
            .GetCultures(CultureTypes.SpecificCultures)
            .Select(ci => new RegionInfo(ci.Name))
            .FirstOrDefault(ri => ri.ISOCurrencySymbol == localSymbol);
        if (cultureInfo is null)
            return null;
        
        var currency = new CurrencyDto()
        {
            Name = cultureInfo.CurrencyEnglishName,
            ISOCode = cultureInfo.ISOCurrencySymbol,
            Symbol = cultureInfo.CurrencySymbol
        };
        
        return currency;
    }
}