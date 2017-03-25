using AutoMapper;
using CSW.BookLibrary.EntityLayer.Service;
using CSW.BookLibrary.QueryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSW.BookLibrary.QueryLayer
{
    public class AuthorQueryService : IAuthorQueryService
    {
        #region EntityServices ---------------
        private readonly IAuthorEntityService _authorEntityService;
        #endregion
        #region Constructor ------------------
        public AuthorQueryService(IAuthorEntityService authorEntityService)
        {
            this._authorEntityService = authorEntityService;           
        }
        #endregion
        #region IAuthorQueryService  
        public AuthorDto FindById(Guid id)
        {
            var entity = this._authorEntityService.Get(id);

            return Mapper.Map<AuthorDto>(entity);
        }
        public IEnumerable<AuthorDto> Find()
        {
            var list = this._authorEntityService.FindAll();
            return Mapper.Map<IEnumerable<AuthorDto>>(list);
        }
        #endregion
    }
}
