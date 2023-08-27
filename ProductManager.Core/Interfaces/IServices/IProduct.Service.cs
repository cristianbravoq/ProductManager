using System.Collections.Generic;
using System.Threading.Tasks;

using ProductManager.Core.DTOs.Product;

namespace ProductManager.Core.Interfaces.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ListaProductoDTO>> ObtenerTodosLosProductosAsync();
        Task<DetallesProductoDTO> ObtenerDetallesProductoAsync(int productoId);
        Task CrearProductoAsync(ProductoDTO productoDTO);
        Task ActualizarProductoAsync(int productoId, ProductoDTO productoDTO);
        Task<IEnumerable<DetallesProductoDTO>> BuscarProductosAsync(BusquedaProductoDTO busquedaDTO);
        Task EliminarProductoAsync(int productoId);
    }
}
