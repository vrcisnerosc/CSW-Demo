using System;

namespace CSW.BookLibrary.Site.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorName { get { return string.Concat(AuthorFirstName, " ", AuthorLastName); } }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}