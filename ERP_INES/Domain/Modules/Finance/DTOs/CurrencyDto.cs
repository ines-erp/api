namespace ERP_INES.Domain.Modules.Finance.DTOs;

public class CurrencyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string ISOCode { get; set; }
}