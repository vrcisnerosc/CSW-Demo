using CSW.BookLibrary.EntityLayer.Context;
using CSW.BookLibrary.EntityLayer.Service;
using CSW.BookLibrary.TaskLayer.Model;
using System;
using System.Data.Entity.Core;

namespace CSW.BookLibrary.TaskLayer
{
    public class CategoryService : ICategoryService
    {
        #region Services ---------------------
        private readonly ICategoryEntityService _categoryEntityService;
        #endregion
        #region Constructor ------------------
        public CategoryService(ICategoryEntityService categoryEntityService)
        {
            this._categoryEntityService = categoryEntityService;
        }
        #endregion
        #region Methods ----------------------
        private Category CreateOrUpdate(CategoryBaseEvent @event, Category entity)
        {
            entity.Name = @event.Name;
            entity.Description = @event.Description;

            return entity;
        }
        #endregion
        #region IAuthorService               
        public void Add(CategoryCreateEvent @event)
        {
            var entity = new Category();

            entity = this.CreateOrUpdate(@event, entity);

            entity.Id = Guid.NewGuid();

            this._categoryEntityService.Add(entity);
            this._categoryEntityService.Save();

            @event.Id = entity.Id;
        }

        public void Delete(Guid id)
        {
            var entity = this._categoryEntityService.Get(id);

            if (entity == null)
                throw new ObjectNotFoundException();

            this._categoryEntityService.Delete(entity);
            this._categoryEntityService.Save();
        }

        public void Update(CategoryUpdateEvent @event)
        {
            var entity = this._categoryEntityService.Get(@event.Id);

            if (entity == null)
                throw new ObjectNotFoundException();

            entity = this.CreateOrUpdate(@event, entity);

            this._categoryEntityService.Edit(entity);
            this._categoryEntityService.Save();
        }
        #endregion
    }
}
