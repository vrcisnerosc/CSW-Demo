using CSW.BookLibrary.QueryLayer.Mapping;
using CSW.BookLibrary.QueryLayer.Model;
using CSW.BookLibrary.Rest.Model;

namespace CSW.BookLibrary.Rest
{
    public static class MappingConfig
    {
        public static void Register()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AuthorDto, AuthorRep>();
                cfg.CreateMap<AuthorDto, AuthorListRep>();

                cfg.CreateMap<CategoryDto, CategoryRep>();
                cfg.CreateMap<CategoryDto, CategoryListRep>();

                cfg.CreateMap<BookDto, BookRep>();
                cfg.CreateMap<BookDto, BookListRep>();

                cfg.AddProfile<QueryMappingProfile>();
            });
        }
    }
}