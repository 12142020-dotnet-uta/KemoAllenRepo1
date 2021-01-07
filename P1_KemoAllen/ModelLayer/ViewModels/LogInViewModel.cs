using System;
using System.ComponentModel.DataAnnotations;


namespace ModelLayer.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
        }

        [StringLength(20, ErrorMessage = "The user name must have atleast 1 letter.", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "User Name")]
        public string Uname { get; set; }

        //Password
    }

}

