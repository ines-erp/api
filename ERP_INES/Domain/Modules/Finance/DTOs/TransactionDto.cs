using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Domain.Modules.Finance.DTOs;

public class TransactionDto
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
    
    public TransactionType TransactionType { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public TransactionCategory? TransactionCategory { get; set; }
}