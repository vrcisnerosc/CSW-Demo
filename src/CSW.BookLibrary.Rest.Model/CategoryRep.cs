using System;
using System.ComponentModel.DataAnnotations;

namespace CSW.BookLibrary.Rest.Model
{
    public abstract class BaseCategoryRep
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }        
    }

    public class CategoryPostRep : BaseCategoryRep
    {
    }

    public class CategoryListRep : BaseCategoryRep
    {
        public Guid Id { get; set; }
    }

    public class CategoryRep : BaseCategoryRep
    {
        public Guid Id { get; set; }
    }
}
