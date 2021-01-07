using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
        }
        public Guid userId { get; set; } = Guid.NewGuid();

		[StringLength(20, ErrorMessage = "The first name must be from 1 to 20 characters.", MinimumLength = 1)]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		[Required]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }


		[StringLength(20, ErrorMessage = "The last name must be from 1 to 20 characters.", MinimumLength = 1)]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		[Required]
		[Display(Name = "First Name")]
		public string LastName { get; set; }

		//View order history

		//Pfp
	}
}
