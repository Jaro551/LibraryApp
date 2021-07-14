using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAppMVC.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual Author Author { get; set; }
    }
}