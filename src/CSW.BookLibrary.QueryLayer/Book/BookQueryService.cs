using AutoMapper;
using CSW.BookLibrary.EntityLayer.Service;
using CSW.BookLibrary.QueryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSW.BookLibrary.QueryLayer
{
    public class BookQueryService : IBookQueryService
    {
        #region EntityServices ---------------
        private readonly IBookEntityService _bookEntityService;
        #endregion
        #region Constructor ------------------
        public BookQueryService(IBookEntityService bookEntityService)
        {
            this._bookEntityService = bookEntityService;
        }
        #endregion
        #region IBookQueryService  
        public BookDto FindById(Guid id)
        {
            var entity = this._bookEntityService.Get(id);

            return Mapper.Map<BookDto>(entity);
        }
        public IEnumerable<BookDto> Find()
        {
            var list = this._bookEntityService.FindAll();
            return Mapper.Map<IEnumerable<BookDto>>(list);
        }
        public IEnumerable<BookDto> FindByAuthor(Guid id)
        {
            var list = this._bookEntityService.FindAll().Where(o => o.AuthorId == id);
            return Mapper.Map<IEnumerable<BookDto>>(list);
        }
        public IEnumerable<BookDto> FindByCategory(Guid id)
        {
            var list = this._bookEntityService.FindAll().Where(o => o.CategoryId == id);
            return Mapper.Map<IEnumerable<BookDto>>(list);
        }
        #endregion
    }
}
