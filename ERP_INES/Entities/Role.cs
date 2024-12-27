namespace ERP_INES.Entities;

public class Role
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public PermissionScope Scope { get; set; }
    public List<Permission> Permission { get; set; }
}