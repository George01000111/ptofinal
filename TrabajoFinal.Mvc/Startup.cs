using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrabajoFinal.Mvc.Startup))]
namespace TrabajoFinal.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
