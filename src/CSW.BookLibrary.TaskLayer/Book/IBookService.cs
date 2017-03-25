using CSW.BookLibrary.TaskLayer.Model;
using System;

namespace CSW.BookLibrary.TaskLayer
{
    public interface IBookService
    {
        void Add(BookCreateEvent @event);
        void Update(BookUpdateEvent @event);
        void Delete(Guid id);
    }
}
