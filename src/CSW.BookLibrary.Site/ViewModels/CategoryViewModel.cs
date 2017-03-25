using CSW.BookLibrary.Site.Models;
using System.Collections.Generic;

namespace CSW.BookLibrary.Site.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Categories = new List<Category>();
        }

        public List<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }
        public string DisplayMode { get; set; }
    }
}