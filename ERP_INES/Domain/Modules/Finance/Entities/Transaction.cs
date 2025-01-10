namespace ERP_INES.Domain.Modules.Finance.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? PaidBy { get; set; }
    public string? ReceivedBy { get; set; }

    public Guid PaymentMethodId { get; set; }
    public Guid TransactionCategoryId { get; set; }
    public Guid TransactionTypeId { get; set; }

    public TransactionType TransactionType { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; }
    public TransactionCategory? TransactionCategory { get; set; }
}