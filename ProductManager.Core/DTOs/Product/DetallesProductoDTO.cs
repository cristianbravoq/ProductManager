using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Core.DTOs.Product
{
    public class DetallesProductoDTO
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaID { get; set; }
        public string NombreCategoria { get; set; }
        public decimal Precio { get; set; }
        public int CantidadDisponible { get; set; }
    }
}
