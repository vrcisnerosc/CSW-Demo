using CSW.BookLibrary.Rest.Model;
using CSW.BookLibrary.Site.Models;

namespace CSW.BookLibrary.Site
{
    public static class MappingConfig
    {
        public static void Register()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CategoryRep, Category>();
            });
        }
    }
}