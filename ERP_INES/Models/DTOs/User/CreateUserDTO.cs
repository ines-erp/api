namespace ERP_INES.Models.DTOs.User;

public class CreateUserDTO
{
    public required string Name { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    // public required List<Role> Roles;
}