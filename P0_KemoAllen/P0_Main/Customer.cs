using System;
using System.ComponentModel.DataAnnotations;

namespace P0_KemoAllen
{
    public class Customer:User
    {
        public Customer()
        {
            userId = Guid.NewGuid();
        }
        public Customer(string fName = "null", string lName = "null")
        {
            firstName = fName;
            lastName = lName;
            userId = Guid.NewGuid();

        }

        //User's id number
        [Key]
        public Guid userId { get; set;}
        // public Guid UserId
        // {
        //     get { return userId; }
        //     set { userId = value; }
        // }
        //User's first name
        private string firstName { get; set;}
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        //User's last name
        private string lastName { get; set;}
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        
    }
}