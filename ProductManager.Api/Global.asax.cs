using System.Net.Http.Formatting;
using System.Web.Http;

using ProductManager.Core.Interfaces.IRepositories;
using ProductManager.Core.Interfaces.IServices;
using ProductManager.Core.Services;
using ProductManager.Infrastructure.Repositories;

using Unity;
using Unity.WebApi;

namespace ProductManager.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

            // Configurar la inyección de dependencias
            ConfigureDependencyInjection(GlobalConfiguration.Configuration);
        }

        private void ConfigureDependencyInjection(HttpConfiguration config)
        {
            // Crear un contenedor de Unity
            var container = new UnityContainer();

            // Registrar servicios y repositorios en Unity
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IAuthenticationRepository, AuthenticationRepository>();
            // ...

            // Configurar Web API para usar Unity para la resolución de dependencias
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}