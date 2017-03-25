using CSW.BookLibrary.EntityLayer.Context;
using CSW.BookLibrary.EntityLayer.Service;
using CSW.BookLibrary.TaskLayer.Model;
using System;
using System.Data.Entity.Core;

namespace CSW.BookLibrary.TaskLayer
{
    public class BookService : IBookService
    {
        #region Services ---------------------
        private readonly IBookEntityService _bookEntityService;
        #endregion
        #region Constructor ------------------
        public BookService(IBookEntityService bookEntityService)
        {
            this._bookEntityService = bookEntityService;
        }
        #endregion
        #region Methods ----------------------
        private Book CreateOrUpdate(BookBaseEvent @event, Book entity)
        {
            entity.Name = @event.Name;
            entity.AuthorId = @event.AuthorId;
            entity.CategoryId = @event.CategoryId;

            return entity;
        }
        #endregion
        #region IBookService               
        public void Add(BookCreateEvent @event)
        {
            var entity = new Book();

            entity = this.CreateOrUpdate(@event, entity);

            entity.Id = Guid.NewGuid();

            this._bookEntityService.Add(entity);
            this._bookEntityService.Save();

            @event.Id = entity.Id;
        }

        public void Delete(Guid id)
        {
            var entity = this._bookEntityService.Get(id);

            if (entity == null)
                throw new ObjectNotFoundException();

            this._bookEntityService.Delete(entity);
            this._bookEntityService.Save();
        }

        public void Update(BookUpdateEvent @event)
        {
            var entity = this._bookEntityService.Get(@event.Id);

            if (entity == null)
                throw new ObjectNotFoundException();

            entity = this.CreateOrUpdate(@event, entity);

            this._bookEntityService.Edit(entity);
            this._bookEntityService.Save();
        }
        #endregion
    }
}
