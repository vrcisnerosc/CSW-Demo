using System;

namespace CSW.BookLibrary.TaskLayer.Model
{
    public class AuthorBaseEvent
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
    }

    public class AuthorCreateEvent : AuthorBaseEvent
    {
       
    }

    public class AuthorUpdateEvent : AuthorBaseEvent
    {
        
    }
}
