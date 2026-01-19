using Microsoft.EntityFrameworkCore;
using SportPlusApi.Models;

namespace SportPlusApi.Data
{
    // Esta clase es el "puente" entre tu código y la base de datos
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Esto creará la tabla de Productos
        public DbSet<Producto> Productos { get; set; }
    }
}