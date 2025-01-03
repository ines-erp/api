namespace ERP_INES.Domain.Modules.Finance.DTOs;

public class PaymentMethodDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}