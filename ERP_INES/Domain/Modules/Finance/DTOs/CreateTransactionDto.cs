using System.ComponentModel.DataAnnotations;
using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Domain.Modules.Finance.DTOs;

public class CreateTransactionDto
{
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    [Required]
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public string? PaidBy { get; set; }
    public string? ReceivedBy { get; set; }
    [Required]
    public Guid TransactionTypeId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public Guid TransactionCategoryId { get; set; }

}