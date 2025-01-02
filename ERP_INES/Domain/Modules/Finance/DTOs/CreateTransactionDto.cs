using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Domain.Modules.Finance.DTOs;

public class CreateTransactionDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Type { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? PaidBy { get; set; }
    public string? RecievedBy { get; set; }
    
    public Guid CurrencyId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public Guid TransactionCategoryId { get; set; }

}