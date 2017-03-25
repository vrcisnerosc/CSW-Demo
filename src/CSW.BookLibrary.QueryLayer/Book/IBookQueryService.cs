using CSW.BookLibrary.QueryLayer.Model;
using System;
using System.Collections.Generic;

namespace CSW.BookLibrary.QueryLayer
{
    public  interface IBookQueryService
    {
        BookDto FindById(Guid id);
        IEnumerable<BookDto> Find();
        IEnumerable<BookDto> FindByAuthor(Guid id);
        IEnumerable<BookDto> FindByCategory(Guid id);
    }
}
