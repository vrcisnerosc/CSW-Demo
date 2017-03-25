using CSW.BookLibrary.EntityLayer.Service;
using CSW.BookLibrary.Infrastructure.Dependency;
using CSW.BookLibrary.QueryLayer;
using CSW.BookLibrary.TaskLayer;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace CSW.BookLibrary.Rest
{
    public static class DependencyConfig
    {
        internal static void Configure(HttpConfiguration config)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IAuthorEntityService, AuthorEntityService>();
            container.RegisterType<IAuthorService, AuthorService>();
            container.RegisterType<IAuthorQueryService, AuthorQueryService>();

            container.RegisterType<ICategoryEntityService, CategoryEntityService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ICategoryQueryService, CategoryQueryService>();

            container.RegisterType<IBookEntityService, BookEntityService>();
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<IBookQueryService, BookQueryService>();

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}