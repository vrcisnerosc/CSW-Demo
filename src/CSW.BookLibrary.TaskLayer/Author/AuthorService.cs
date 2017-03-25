using CSW.BookLibrary.EntityLayer.Context;
using CSW.BookLibrary.EntityLayer.Service;
using CSW.BookLibrary.TaskLayer.Model;
using System;
using System.Data.Entity.Core;

namespace CSW.BookLibrary.TaskLayer
{
    public class AuthorService : IAuthorService
    {
        #region Services ---------------------
        private readonly IAuthorEntityService _authorEntityService;
        #endregion
        #region Constructor ------------------
        public AuthorService(IAuthorEntityService authorEntityService)
        {
            this._authorEntityService = authorEntityService;
        }
        #endregion
        #region Methods ----------------------
        private Author CreateOrUpdate(AuthorBaseEvent @event, Author entity)
        {
            entity.FirstName = @event.FirstName;
            entity.LastName = @event.LastName;
            entity.Country = @event.Country;

            return entity;
        }
        #endregion
        #region IAuthorService               
        public void Add(AuthorCreateEvent @event)
        {
            var entity = new Author();

            entity = this.CreateOrUpdate(@event, entity);

            entity.Id = Guid.NewGuid();

            this._authorEntityService.Add(entity);
            this._authorEntityService.Save();

            @event.Id = entity.Id;
        }

        public void Delete(Guid id)
        {
            var entity = this._authorEntityService.Get(id);

            if (entity == null)
                throw new ObjectNotFoundException();

            this._authorEntityService.Delete(entity);
            this._authorEntityService.Save();
        }

        public void Update(AuthorUpdateEvent @event)
        {
            var entity = this._authorEntityService.Get(@event.Id);

            if (entity == null)
                throw new ObjectNotFoundException();

            entity = this.CreateOrUpdate(@event, entity);

            this._authorEntityService.Edit(entity);
            this._authorEntityService.Save();
        }
        #endregion
    }
}
