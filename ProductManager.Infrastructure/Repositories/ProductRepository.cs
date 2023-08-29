
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using ProductManager.Core.Entities.ProductManagerDB;
using ProductManager.Core.Interfaces.IRepositories;
using ProductManager.Infrastructure.Data;

namespace ProductManager.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductManagerDBContext productManager_Context;

        public ProductRepository(ProductManagerDBContext _productManagerDB)
        {
            this.productManager_Context = _productManagerDB;
        }

        public async Task<Producto> ObtenerPorIdAsync(int productoId)
        {
            return await productManager_Context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.ProductoID == productoId);
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            return await productManager_Context.Productos.ToListAsync();
        }

        public async Task<IEnumerable<Producto>> BuscarProductosPorNombreAsync(string nombre)
        {
            return await productManager_Context.Productos.Include(p => p.Categoria)
                .Where(p => p.NombreProducto.Contains(nombre))
                .ToListAsync();
        }

        public async Task<IEnumerable<Producto>> BuscarProductosPorRangoPrecioAsync(decimal precioMinimo, decimal precioMaximo)
        {
            return await productManager_Context.Productos.Include(p => p.Categoria)
                .Where(p => p.Precio >= precioMinimo && p.Precio <= precioMaximo)
                .ToListAsync();
        }

        public async Task AgregarAsync(Producto producto)
        {
            productManager_Context.Productos.Add(producto);
            await productManager_Context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Producto producto)
        {
            productManager_Context.Entry(producto).State = EntityState.Modified;
            await productManager_Context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int productoId)
        {
            var producto = await productManager_Context.Productos.FindAsync(productoId);
            if (producto != null)
            {
                productManager_Context.Productos.Remove(producto);
                await productManager_Context.SaveChangesAsync();
            }
        }
    }
}
