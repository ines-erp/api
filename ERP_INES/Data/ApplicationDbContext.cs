using ERP_INES.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}