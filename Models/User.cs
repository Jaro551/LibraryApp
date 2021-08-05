using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryAppMVC.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Musisz podać login!")]
        [Display(Name = "Login")]
        [StringLength(100, MinimumLength = 3)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Musisz podać swoje imię!")]
        [Display(Name = "Imię")]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Musisz podać swoje nazwisko!")]
        [Display(Name = "Nazwisko")]
        [StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Niewłaściwy adres e-mail")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Hasło jest wymagane")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Hasło za krótkie, powinno składać się z minumum 8 znaków")]
        public string Password { get; set; }

        [Display(Name = "Potwierdź hasło")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła nie są identyczne")]
        public string PswdConfirmed { get; set; }

        public string FullName
        {
            get 
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual LibraryCard LibraryCard { get; set; }
    }
}