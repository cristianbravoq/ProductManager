
using Microsoft.Owin;

using Owin;

using ProductManager.Infrastructure.Data;

[assembly: OwinStartup(typeof(ProductManager.Api.Startup))]

namespace ProductManager.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(ProductManagerDBContext.Create);
        }
    }
}