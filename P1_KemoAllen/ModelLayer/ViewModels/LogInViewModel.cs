using System;
using System.ComponentModel.DataAnnotations;


namespace ModelLayer.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
        }
        //User name
        [StringLength(20, ErrorMessage = "The user name must have atleast 1 letter.", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        //Password
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}

