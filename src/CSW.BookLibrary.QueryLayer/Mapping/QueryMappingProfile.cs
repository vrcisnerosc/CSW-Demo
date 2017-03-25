using CSW.BookLibrary.EntityLayer.Context;
using CSW.BookLibrary.QueryLayer.Model;

namespace CSW.BookLibrary.QueryLayer.Mapping
{
    public class QueryMappingProfile : AutoMapper.Profile
    {
        public QueryMappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Book, BookDto>();
        }
    }
}
