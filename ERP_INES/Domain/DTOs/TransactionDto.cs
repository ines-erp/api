using ERP_INES.Domain.Entities;

namespace ERP_INES.Domain.DTOs;

public class TransactionDto
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
    
    public Currency Currency { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public TransactionCategory? TransactionCategory { get; set; }
}