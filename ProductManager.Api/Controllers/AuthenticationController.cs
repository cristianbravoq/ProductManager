using System.Threading.Tasks;
using System.Web.Http;

using ProductManager.Api.Modules;
using ProductManager.Core.DTOs.Authentication;
using ProductManager.Core.Interfaces.IServices;

namespace ProductManager.Api.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Authentication(LoginDTO login)
        {
            var validation = await IsValidUser(login);
            if (!validation.Item1)
            {
                return Unauthorized();
            }
            var token = TokenGenerator.GenerateTokenJwt(validation.Item2);
            return Ok(new { token });
        }

        private async Task<(bool, AuthenticationDTO)> IsValidUser(LoginDTO login)
        {
            var user = await _authenticationService.GetAuthentication(login);
            return (user != null, user);
        }
    }
}
