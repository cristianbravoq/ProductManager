using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductManager.Api.Controllers
{
    public class AuthenticationController : ApiController
    {
        [HttpGet]
        public string ObtenerTodosLosProductos()
        {
            return "Respuesta Exitosa";
        }
    }
}
