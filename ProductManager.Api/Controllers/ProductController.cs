using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

using ProductManager.Core.DTOs.Product;
using ProductManager.Core.Interfaces.IServices;
using ProductManager.Core.Services;
using ProductManager.Infrastructure.Data;
using ProductManager.Infrastructure.Repositories;

namespace ProductManager.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ProductServices _productoService = new ProductServices(new ProductRepository(ProductManagerDBContext.Create()));

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerTodosLosProductos()
        {
            var productos = await _productoService.ObtenerTodosLosProductosAsync();
            return Ok(productos);
        }

        //[HttpGet]
        //public async Task<IHttpActionResult> ObtenerDetallesProducto(int id)
        //{
        //    var producto = await _productoService.ObtenerDetallesProductoAsync(id);
        //    if (producto == null)
        //    {
        //        return NotFound(); // Producto no encontrado
        //    }
        //    return Ok(producto);
        //}

        [HttpPost]
        public async Task<IHttpActionResult> CrearProducto(ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Datos inválidos
            }

            await _productoService.CrearProductoAsync(productoDTO);
            return Ok("Producto creado exitosamente");
        }

        [HttpPut]
        public async Task<IHttpActionResult> ActualizarProducto(int id, ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Datos inválidos
            }

            try
            {
                await _productoService.ActualizarProductoAsync(id, productoDTO);
            }
            catch (Exception)
            {
                return NotFound(); // Producto no encontrado
            }

            return Ok("Producto actualizado exitosamente");
        }

        //[HttpGet]
        //public async Task<IHttpActionResult> BuscarProductos([FromUri] BusquedaProductoDTO busquedaDTO)
        //{
        //    var productos = await _productoService.BuscarProductosAsync(busquedaDTO);
        //    if (!productos.Any())
        //    {
        //        return NotFound(); // Productos no encontrados
        //    }
        //    return Ok(productos);
        //}

        [HttpDelete]
        public async Task<IHttpActionResult> EliminarProducto(int id)
        {
            try
            {
                await _productoService.EliminarProductoAsync(id);
            }
            catch (Exception)
            {
                return NotFound(); // Producto no encontrado
            }

            return Ok("Producto eliminado exitosamente");
        }
    }
}
