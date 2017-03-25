using CSW.BookLibrary.TaskLayer.Model;
using System;

namespace CSW.BookLibrary.TaskLayer
{
    public interface IAuthorService
    {
        void Add(AuthorCreateEvent @event);
        void Update(AuthorUpdateEvent @event);
        void Delete(Guid id);
    }
}
