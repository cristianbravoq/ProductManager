using System.Collections.Generic;
using System.Threading.Tasks;

using ProductManager.Core.Entities.ProductManagerDB;

namespace ProductManager.Core.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        Task<Productos> ObtenerPorIdAsync(int productoId);
        Task<IEnumerable<Productos>> ObtenerTodosAsync();
        Task<IEnumerable<Productos>> BuscarProductosPorNombreAsync(string nombre);
        Task<IEnumerable<Productos>> BuscarProductosPorRangoPrecioAsync(decimal precioMinimo, decimal precioMaximo);
        Task AgregarAsync(Productos producto);
        Task ActualizarAsync(Productos producto);
        Task EliminarAsync(int productoId);
    }
}
