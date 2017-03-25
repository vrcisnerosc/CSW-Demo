using CSW.BookLibrary.Infrastructure.Proxy;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Unity.Mvc5;

namespace CSW.BookLibrary.Site
{
    public static class DependencyConfig
    {
        internal static void Configure()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IHttpProxyService, HttpProxyService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}