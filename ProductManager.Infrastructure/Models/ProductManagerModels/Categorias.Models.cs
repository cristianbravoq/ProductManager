using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManager.Infrastructure.Models
{
    [Table("Categorias", Schema ="dbo")]
    public class Categorias
    {
        [Key]
        public int CategoriaID { get; set; }
        public string NombreCategoria { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
