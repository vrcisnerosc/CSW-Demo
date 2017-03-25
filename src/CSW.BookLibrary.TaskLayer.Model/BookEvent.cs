using System;

namespace CSW.BookLibrary.TaskLayer.Model
{
    public class BookBaseEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class BookCreateEvent : BookBaseEvent
    {
       
    }

    public class BookUpdateEvent : BookBaseEvent
    {
        
    }
}
