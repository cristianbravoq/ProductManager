using System.Data.Entity;

using ProductManager.Core.Entities.ProductManagerDB;

namespace ProductManager.Infrastructure.Data
{
    public class ProductManagerDBContext : DbContext
    {
        public ProductManagerDBContext() : base("ProductManagerContext") { }

        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        public static ProductManagerDBContext Create()
        {
            return new ProductManagerDBContext();
        }
    }
}
