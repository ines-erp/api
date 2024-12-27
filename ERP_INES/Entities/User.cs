namespace ERP_INES.Entities;

public class User
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Role> Roles { get; set; }

}