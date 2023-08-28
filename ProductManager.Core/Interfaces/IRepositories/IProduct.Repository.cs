using System.Collections.Generic;
using System.Threading.Tasks;

using ProductManager.Core.Entities.ProductManagerDB;

namespace ProductManager.Core.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        Task<Producto> ObtenerPorIdAsync(int productoId);
        Task<IEnumerable<Producto>> ObtenerTodosAsync();
        Task<IEnumerable<Producto>> BuscarProductosPorNombreAsync(string nombre);
        Task<IEnumerable<Producto>> BuscarProductosPorRangoPrecioAsync(decimal precioMinimo, decimal precioMaximo);
        Task AgregarAsync(Producto producto);
        Task ActualizarAsync(Producto producto);
        Task EliminarAsync(int productoId);
    }
}
