using CSW.BookLibrary.TaskLayer.Model;
using System;

namespace CSW.BookLibrary.TaskLayer
{
    public  interface ICategoryService
    {
        void Add(CategoryCreateEvent @event);
        void Update(CategoryUpdateEvent @event);
        void Delete(Guid id);
    }
}
