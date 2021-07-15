using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryAppMVC.Models
{
    public class Book
    {
        public int BookID { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Musisz podać tytuł")]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        public int AuthorID { get; set; }

        [Display(Name = "Data wydania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public virtual Author Author { get; set; }
        public virtual LibraryCard LibraryCard { get; set; }
    }
}