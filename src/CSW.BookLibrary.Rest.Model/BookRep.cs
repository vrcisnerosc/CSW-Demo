using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSW.BookLibrary.Rest.Model
{
    public abstract class BaseBookRep
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }

    public class BookPostRep : BaseBookRep
    {
    }

    public class BookListRep : BaseBookRep
    {
        public Guid Id { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string CategoryName { get; set; }
    }

    public class BookRep : BaseBookRep
    {
        public Guid Id { get; set; }
    }
}
