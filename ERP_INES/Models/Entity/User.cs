namespace ERP_INES.Models.Entity;

public class User
{
    public Guid Id { get; private set; }
    public required string Name { get; set; }
    public required string Password { get; set; }
    // public required List<Role> Roles;
    
}