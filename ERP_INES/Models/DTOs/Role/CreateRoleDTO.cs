using ERP_INES.Models.Enums;

namespace ERP_INES.Models.DTOs.Role;

public class CreateRoleDTO
{
    public required string Name { get; set; }
    public required PermissionScope Scope { get; set; }
    public required List<PermissionLevel> Permissions { get; set; }
}