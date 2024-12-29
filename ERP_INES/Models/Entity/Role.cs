using ERP_INES.Models.Enums;

namespace ERP_INES.Models.Entity;

public class Role
{
    public Guid Id { get; private set; }
    public required string Name { get; set; }
    public required PermissionScope Scope { get; set; }
    public required List<PermissionLevel> Permissions { get; set; }
}