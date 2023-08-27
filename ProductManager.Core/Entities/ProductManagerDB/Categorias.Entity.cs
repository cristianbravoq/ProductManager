using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Core.Entities.ProductManagerDB
{
    [Table("Categorias", Schema = "dbo")]
    public class Categorias
    {
        [Key]
        public int CategoriaID { get; set; }
        public string NombreCategoria { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
