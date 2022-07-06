using Microsoft.EntityFrameworkCore;

namespace Reto.Contpaqi.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
    }
}
