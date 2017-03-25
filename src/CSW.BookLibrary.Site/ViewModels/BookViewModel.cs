using CSW.BookLibrary.Site.Models;
using System.Collections.Generic;

namespace CSW.BookLibrary.Site.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            Books = new List<Book>();
        }

        public List<Book> Books { get; set; }
        public Book SelectedBook { get; set; }
        public string DisplayMode { get; set; }       
    }
}