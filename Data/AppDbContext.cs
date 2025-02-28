using Microsoft.EntityFrameworkCore;
using ReservaApi.Models;

namespace ReservaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>().HasData(
                new Servicio { Id = 1, Nombre = "Peluquería" },
                new Servicio { Id = 2, Nombre = "Spa" },
                new Servicio { Id = 3, Nombre = "Masaje" },
                new Servicio { Id = 4, Nombre = "Depilación" }
            );
        }
    }
}
