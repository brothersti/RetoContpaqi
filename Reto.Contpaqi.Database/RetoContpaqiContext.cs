using Microsoft.EntityFrameworkCore;
using Reto.Contpaqi.Database.Models;

namespace Reto.Contpaqi.Database
{
    public class RetoContpaqiContext : DbContext
    {
        public RetoContpaqiContext(DbContextOptions<RetoContpaqiContext> options) : base(options)
        {

        }

        public DbSet<Employee> Empleados { get; set; }
        public DbSet<Direccion> Direccions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>().ToTable("Empleado");
            builder.Entity<Direccion>().ToTable("Direccion");
        }
    }
}