using System;
using System.ComponentModel.DataAnnotations;

namespace CSW.BookLibrary.Rest.Model
{
    public abstract class BaseAuthorRep
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Country { get; set; }
    }

    public class AuthorPostRep : BaseAuthorRep
    {
    }

    public class AuthorListRep : BaseAuthorRep
    {
        public Guid Id { get; set; }
    }

    public class AuthorRep : BaseAuthorRep
    {
        public Guid Id { get; set; }
    }
}
