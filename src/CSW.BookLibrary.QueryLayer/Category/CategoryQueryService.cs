using AutoMapper;
using CSW.BookLibrary.EntityLayer.Service;
using CSW.BookLibrary.QueryLayer.Model;
using System;
using System.Collections.Generic;

namespace CSW.BookLibrary.QueryLayer
{
    public class CategoryQueryService : ICategoryQueryService
    {
        #region EntityServices ---------------
        private readonly ICategoryEntityService _categoryEntityService;
        #endregion
        #region Constructor ------------------
        public CategoryQueryService(ICategoryEntityService categoryEntityService)
        {
            this._categoryEntityService = categoryEntityService;
        }
        #endregion
        #region ICategoryQueryService       
        public CategoryDto FindById(Guid id)
        {
            var entity = this._categoryEntityService.Get(id);

            return Mapper.Map<CategoryDto>(entity);
        }
        public IEnumerable<CategoryDto> Find()
        {
            var list = this._categoryEntityService.FindAll();
            return Mapper.Map<IEnumerable<CategoryDto>>(list);
        }
        #endregion
    }
}
