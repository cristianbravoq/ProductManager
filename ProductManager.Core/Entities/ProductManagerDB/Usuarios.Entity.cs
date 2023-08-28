using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManager.Core.Entities.ProductManagerDB
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(128)]
        public string Contraseña { get; set; }

        [Required]
        [MaxLength(20)]
        public string Rol { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public DateTime? UltimoAcceso { get; set; }
    }
}
}
