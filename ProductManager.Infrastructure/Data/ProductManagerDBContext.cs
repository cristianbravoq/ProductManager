using System.Data.Entity;

using ProductManager.Core.Entities.ProductManagerDB;

namespace ProductManager.Infrastructure.Data
{
    public class ProductManagerDBContext : DbContext
    {
        private static ProductManagerDBContext productManagerDBContext = null;

        public ProductManagerDBContext() : base("ProductManagerContext") { }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public static ProductManagerDBContext Create()
        {
            //if (productManagerDBContext == null)
            //    productManagerDBContext = new ProductManagerDBContext();
            return new ProductManagerDBContext();
        }
    }
}
