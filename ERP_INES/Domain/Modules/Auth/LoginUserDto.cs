using System.ComponentModel.DataAnnotations;

namespace ERP_INES.Domain.Modules.Auth;

public class LoginUserDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}