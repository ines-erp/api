using ERP_INES.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Data;

public class InesDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost:5432;DataBase=ines_erp;Username=postgres;Password=postgres");
}