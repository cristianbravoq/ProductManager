using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

using ProductManager.Core.DTOs.Product;
using ProductManager.Core.Interfaces.IServices;

namespace ProductManager.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerTodosLosProductos()
        {
            var productos = await _productService.ObtenerTodosLosProductosAsync();
            return Ok(productos);
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerDetallesProducto(int id)
        {
            var producto = await _productService.ObtenerDetallesProductoAsync(id);
            if (producto == null)
            {
                return NotFound(); // Producto no encontrado
            }
            return Ok(producto);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IHttpActionResult> CrearProducto(ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Datos inválidos
            }

            await _productService.CrearProductoAsync(productoDTO);
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
                await _productService.ActualizarProductoAsync(id, productoDTO);
            }
            catch (Exception)
            {
                return NotFound(); // Producto no encontrado
            }

            return Ok("Producto actualizado exitosamente");
        }

        [HttpGet]
        [Route("BuscarProductos")]
        public async Task<IHttpActionResult> BuscarProductos([FromUri] BusquedaProductoDTO busquedaDTO)
        {
            var productos = await _productService.BuscarProductosAsync(busquedaDTO);
            if (!productos.Any())
            {
                return NotFound(); // Productos no encontrados
            }
            return Ok(productos);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> EliminarProducto(int id)
        {
            try
            {
                await _productService.EliminarProductoAsync(id);
            }
            catch (Exception)
            {
                return NotFound(); // Producto no encontrado
            }

            return Ok("Producto eliminado exitosamente");
        }
    }
}