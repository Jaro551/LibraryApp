using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryAppMVC.Models
{
    public class LoginUser
    {
        [Display(Name = "Login")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login jest wymagany")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musisz wprowadzić prawidłowe hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}