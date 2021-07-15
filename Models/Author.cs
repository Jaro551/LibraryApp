using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryAppMVC.Models
{
    public class Author
    {
        public int AuthorID { get; set; }

        [Required(ErrorMessage = "Musisz podać imię autora")]
        [Display(Name = "Imię")]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Musisz podać nazwisko autora")]
        [Display(Name = "Nazwisko")]
        [StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Imię i nazwisko")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual ICollection<Book> Books { get; set; }
    }
}