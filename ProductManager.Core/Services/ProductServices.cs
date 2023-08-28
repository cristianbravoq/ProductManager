using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProductManager.Core.DTOs.Product;
using ProductManager.Core.Entities.ProductManagerDB;
using ProductManager.Core.Interfaces.IRepositories;
using ProductManager.Core.Interfaces.IServices;
namespace ProductManager.Core.Services
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productoRepository;

        public ProductServices(IProductRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<ListaProductoDTO>> ObtenerTodosLosProductosAsync()
        {
            var productos = await _productoRepository.ObtenerTodosAsync();
            return productos.Select(p => new ListaProductoDTO
            {
                ProductoID = p.ProductoID,
                NombreProducto = p.NombreProducto,
                Precio = p.Precio,
                CantidadDisponible = p.CantidadDisponible
            });
        }

        public async Task<DetallesProductoDTO> ObtenerDetallesProductoAsync(int productoId)
        {
            var producto = await _productoRepository.ObtenerPorIdAsync(productoId);
            if (producto == null)
            {
                return null; // Manejo si no se encuentra el producto
            }

            return new DetallesProductoDTO
            {
                ProductoID = producto.ProductoID,
                NombreProducto = producto.NombreProducto,
                Descripcion = producto.Descripcion,
                CategoriaID = (int)producto.CategoriaID,
                NombreCategoria = producto.Categoria.NombreCategoria, // Si tienes una referencia a la categoría
                Precio = producto.Precio,
                CantidadDisponible = producto.CantidadDisponible
            };
        }

        public async Task CrearProductoAsync(ProductoDTO productoDTO)
        {
            var nuevoProducto = new Producto
            {
                NombreProducto = productoDTO.NombreProducto,
                Descripcion = productoDTO.Descripcion,
                CategoriaID = productoDTO.CategoriaID,
                Precio = productoDTO.Precio,
                CantidadDisponible = productoDTO.CantidadDisponible
            };

            await _productoRepository.AgregarAsync(nuevoProducto);
        }

        public async Task ActualizarProductoAsync(int productoId, ProductoDTO productoDTO)
        {
            var productoExistente = await _productoRepository.ObtenerPorIdAsync(productoId);
            if (productoExistente == null)
            {
                throw new Exception("Producto no encontrado");
            }

            productoExistente.NombreProducto = productoDTO.NombreProducto;
            productoExistente.Descripcion = productoDTO.Descripcion;
            productoExistente.CategoriaID = productoDTO.CategoriaID;
            productoExistente.Precio = productoDTO.Precio;
            productoExistente.CantidadDisponible = productoDTO.CantidadDisponible;

            await _productoRepository.ActualizarAsync(productoExistente);
        }

        public async Task<IEnumerable<DetallesProductoDTO>> BuscarProductosAsync(BusquedaProductoDTO busquedaDTO)
        {
            IEnumerable<Producto> productosEncontrados;

            if (!string.IsNullOrEmpty(busquedaDTO.NombreProducto))
            {
                productosEncontrados = await _productoRepository.BuscarProductosPorNombreAsync(busquedaDTO.NombreProducto);
            }
            else
            {
                productosEncontrados = await _productoRepository.BuscarProductosPorRangoPrecioAsync(busquedaDTO.PrecioMinimo, busquedaDTO.PrecioMaximo);
            }

            if (!string.IsNullOrEmpty(busquedaDTO.NombreProducto) &&
                (busquedaDTO.PrecioMinimo > 0 || busquedaDTO.PrecioMaximo > 0))
            {
                productosEncontrados = productosEncontrados.Where(p =>
                    p.Precio >= busquedaDTO.PrecioMinimo && p.Precio <= busquedaDTO.PrecioMaximo);
            }

            return productosEncontrados.Select(p => new DetallesProductoDTO
            {
                ProductoID = p.ProductoID,
                NombreProducto = p.NombreProducto,
                Descripcion = p.Descripcion,
                CategoriaID = (int)p.CategoriaID,
                Precio = p.Precio,
                CantidadDisponible = p.CantidadDisponible
            });
        }

        public async Task EliminarProductoAsync(int productoId)
        {
            await _productoRepository.EliminarAsync(productoId);
        }
    }
}
