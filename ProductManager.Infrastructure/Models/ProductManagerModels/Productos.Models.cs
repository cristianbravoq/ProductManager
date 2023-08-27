using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManager.Infrastructure.Models
{
    [Table("Usuarios", Schema = "dbo")]
    public class Productos
    {
        [Key]
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CantidadDisponible { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> UltimaActualizacion { get; set; }

        [ForeignKey("Categoria")]
        public Nullable<int> CategoriaID { get; set; }

        public virtual Categorias Categoria { get; set; }
    }
}
