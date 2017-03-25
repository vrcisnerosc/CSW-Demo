using CSW.BookLibrary.QueryLayer.Model;
using System;
using System.Collections.Generic;

namespace CSW.BookLibrary.QueryLayer
{
    public  interface ICategoryQueryService
    {
        CategoryDto FindById(Guid id);
        IEnumerable<CategoryDto> Find();
    }
}
