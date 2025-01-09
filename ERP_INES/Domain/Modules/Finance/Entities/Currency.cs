namespace ERP_INES.Domain.Modules.Finance.Entities;

public class Currency
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string ISOCode { get; set; }
    
}