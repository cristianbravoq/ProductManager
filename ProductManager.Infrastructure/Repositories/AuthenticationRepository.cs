using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using ProductManager.Core.Entities.ProductManagerDB;
using ProductManager.Core.Interfaces.IRepositories;
using ProductManager.Infrastructure.Data;

namespace ProductManager.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ProductManagerDBContext productManager_Context;

        public AuthenticationRepository(ProductManagerDBContext _productManagerDB)
        {
            this.productManager_Context = _productManagerDB;
        }

        public async Task<Usuario> AutenticarUsuarioAsync(string nombreUsuario, string contraseña)
        {
            return await productManager_Context.Usuarios
                .FirstOrDefaultAsync(u => u.Nombre == nombreUsuario && u.Contraseña == contraseña);
        }
    }
}
