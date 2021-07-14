using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAppMVC.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}