using CSW.BookLibrary.Site.Models;
using System.Collections.Generic;

namespace CSW.BookLibrary.Site.ViewModels
{
    public class AuthorViewModel
    {
        public AuthorViewModel()
        {
            Authors = new List<Author>();
        }

        public List<Author> Authors { get; set; }
        public Author SelectedAuthor { get; set; }
        public string DisplayMode { get; set; }
    }
}