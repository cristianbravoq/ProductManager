using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductManager.Core.DTOs.Authentication;

namespace ProductManager.Core.Interfaces.IServices
{
    public interface IAuthenticationService
    {
        Task<AuthenticationDTO> GetAuthentication(LoginDTO login);
    }
}
