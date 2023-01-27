using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Assignment03.Models
{
    public class User
    {
        [Required(ErrorMessage ="User Name Required")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not an Email Format")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Confirmed Password Required")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match")]
        public String Password2 { get; set; }
    }
}