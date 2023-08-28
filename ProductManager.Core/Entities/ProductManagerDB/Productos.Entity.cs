using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManager.Core.Entities.ProductManagerDB
{
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreProducto { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int CantidadDisponible { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public DateTime? UltimaActualizacion { get; set; }
    }
}
