using CSW.BookLibrary.Site.Models;
using System;
using System.Collections.Generic;

namespace CSW.BookLibrary.Site.ViewModels
{
    public class HomeViewModel
    {
        public Guid AuthorId { get; set; }
        public List<Book> Books { get; set; }
    }
}