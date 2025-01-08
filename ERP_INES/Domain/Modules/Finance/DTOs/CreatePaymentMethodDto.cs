using System.ComponentModel.DataAnnotations;

namespace ERP_INES.Domain.Modules.Finance.DTOs;

public class CreatePaymentMethodDto
{
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
}