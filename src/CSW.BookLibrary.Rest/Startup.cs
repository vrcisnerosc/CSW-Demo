using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(CSW.BookLibrary.Rest.Startup))]

namespace CSW.BookLibrary.Rest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure((configuration) => { configuration.MapHttpAttributeRoutes(); });

            HttpConfiguration config = new HttpConfiguration();
            DependencyConfig.Configure(config);
            WebApiConfig.Register(config);
            MappingConfig.Register();

            app.UseWebApi(config);
        }
    }
}
