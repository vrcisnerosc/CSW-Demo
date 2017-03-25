using CSW.BookLibrary.QueryLayer.Model;
using System;
using System.Collections.Generic;

namespace CSW.BookLibrary.QueryLayer
{
    public  interface IAuthorQueryService
    {
        AuthorDto FindById(Guid id);
        IEnumerable<AuthorDto> Find();
    }
}
