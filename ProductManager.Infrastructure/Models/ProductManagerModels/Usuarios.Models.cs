using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManager.Infrastructure.Models
{
    [Table("Usuarios", Schema ="dbo")]
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> UltimoAcceso { get; set; }
    }
}
