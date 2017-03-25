using System;

namespace CSW.BookLibrary.TaskLayer.Model
{
    public class CategoryBaseEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CategoryCreateEvent : CategoryBaseEvent
    {
       
    }

    public class CategoryUpdateEvent : CategoryBaseEvent
    {
        
    }
}
