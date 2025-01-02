namespace ERP_INES.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
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
    public Currency Currency { get; set; }

    public Guid PaymentMethodId { get; set; }
    public PyamentMethod PyamentMethod { get; set; }

    public Guid TransactionCategoryId { get; set; }
    public TransactionCategory? Category { get; set; }
}