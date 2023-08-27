using System.Data.Entity;

using ProductManager.Infrastructure.Models;

namespace ProductManager.Infrastructure.Data
{
    public class ProductManagerDBContext : DbContext
    {
        public ProductManagerDBContext() : base("ProductManagerContext")
        {

        }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        public static ProductManagerDBContext Create()
        {
            return new ProductManagerDBContext();
        }
    }
}
