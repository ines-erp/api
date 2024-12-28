using ERP_INES.Entities;

namespace ERP_INES.Repositories;

public interface IRoleRepository : IDisposable
{
    IEnumerable<Role> GetRoles();
    Role GetRoleByID(int roleId);
    void InsertRole(Role role);
    void Save();

}