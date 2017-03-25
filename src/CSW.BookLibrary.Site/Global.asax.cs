using System.Web.Mvc;
using System.Web.Routing;

namespace CSW.BookLibrary.Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyConfig.Configure();
            MappingConfig.Register();
        }
    }
}
