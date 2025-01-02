namespace ERP_INES.Domain.Entities;

public class PaymentMethod
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}