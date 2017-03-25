using System;

namespace CSW.BookLibrary.QueryLayer.Model
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
