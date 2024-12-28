using ERP_INES.Data;
using ERP_INES.Entities;

namespace ERP_INES.Repositories;

public class RoleRepository : IRoleRepository
{
    private InesDbContext _context;

//Constructor that pass the context here
    public RoleRepository(InesDbContext context)
    {
        _context = context;
    }


    public IEnumerable<Role> GetRoles()
    {
        return _context.Roles;
    }

    public Role GetRoleByID(int roleId)
    {
        throw new NotImplementedException();
    }

    public void InsertRole(Role role)
    {
        try
        {
            if (role == null)
                return;

            _context.Roles.Add(role);
            Save();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}