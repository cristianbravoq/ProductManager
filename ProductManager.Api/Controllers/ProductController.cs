using ProductManager.Core.DTOs.Product;
using ProductManager.Core.Interfaces.IServices;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductManager.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerTodosLosProductos()
        {
            try
            {
                var productos = await _productService.ObtenerTodosLosProductosAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerDetallesProducto(int id)
        {
            try
            {
                var producto = await _productService.ObtenerDetallesProductoAsync(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IHttpActionResult> CrearProducto(ProductoDTO productoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _productService.CrearProductoAsync(productoDTO);
                return Ok("Product successfully created");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<IHttpActionResult> ActualizarProducto(int id, ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _productService.ActualizarProductoAsync(id, productoDTO);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok("Product successfully upgraded");
        }

        [HttpGet]
        [Route("BuscarProductos")]
        public async Task<IHttpActionResult> BuscarProductos([FromUri] BusquedaProductoDTO busquedaDTO)
        {
            try
            {
                var productos = await _productService.BuscarProductosAsync(busquedaDTO);

                if (!productos.Any())
                {
                    return NotFound();
                }

                return Ok(productos);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public async Task<IHttpActionResult> EliminarProducto(int id)
        {
            try
            {
                try
                {
                    await _productService.EliminarProductoAsync(id);
                }
                catch (Exception)
                {
                    return NotFound();
                }

                return Ok("Product successfully removed");
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}