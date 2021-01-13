using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
        }
		public Guid userId { get; set; }
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

		//default location
		public Guid DefaultLocationId { get; set; }

		//View order history

		//Pfp
		//public IFormFile IformFileImage { get; set; }
		//public string JpgStringImage { get; set; }
	}
}
