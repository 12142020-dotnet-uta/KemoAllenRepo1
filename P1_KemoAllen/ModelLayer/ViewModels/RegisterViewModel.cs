using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
        }

		public Guid userId { get; set; } = Guid.NewGuid();
		//User Name
		[StringLength(20, ErrorMessage = "The user name must be from 1 to 20 characters.", MinimumLength = 1)]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		[Required]
		[Display(Name = "User Name")]
		public string UserName { get; set; }
		//First name
		[StringLength(20, ErrorMessage = "The first name must be from 1 to 20 characters.", MinimumLength = 1)]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		[Required]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		//last name
		[StringLength(20, ErrorMessage = "The last name must be from 1 to 20 characters.", MinimumLength = 1)]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		//Password
		[Required]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		//default location
		[Display(Name = "Location")]
		public string LocationName { get; set; }
	}
}
