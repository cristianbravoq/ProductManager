using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductManager.Core.Entities.ProductManagerDB;

namespace ProductManager.Core.Interfaces.IRepositories
{
    public interface IAuthenticationRepository
    {
        Task<Usuario> AutenticarUsuarioAsync(string nombreUsuario, string contraseña);
    }
}
