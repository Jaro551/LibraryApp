using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryAppMVC.Models
{
    public class LibraryCard
    {
        [Key]
        [ForeignKey("User")]
        public int UserID { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual User User { get; set; }
    }
}