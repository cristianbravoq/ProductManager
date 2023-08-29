using System.Threading.Tasks;

using ProductManager.Core.DTOs.Authentication;
using ProductManager.Core.Entities.ProductManagerDB;
using ProductManager.Core.Interfaces.IRepositories;
using ProductManager.Core.Interfaces.IServices;

namespace ProductManager.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticateRepository;

        public AuthenticationService(IAuthenticationRepository authenticateRepository)
        {
            _authenticateRepository = authenticateRepository;
        }

        public async Task<AuthenticationDTO> GetAuthentication(LoginDTO login)
        {
            var Auth = await _authenticateRepository.AutenticarUsuarioAsync(login.Usuario, login.Contrasena);
            if (Auth != null)
            {
                var Authentication = new AuthenticationDTO
                {
                    Usuario = Auth.Nombre,
                    Rol = Auth.Rol
                };
                return Authentication;
            }
            return null;
        }
    }
}
