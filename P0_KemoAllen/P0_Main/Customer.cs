using System;
using System.ComponentModel.DataAnnotations;

namespace P0_KemoAllen
{
    public class Customer : IUser
    {
        public Customer()
        {
  
        }
        public Customer(string fName = "null", string lName = "null", string uName = "null")
        {
            firstName = fName;
            lastName = lName;
            userName = uName;

        }

        //User's id number
        [Key]
        public Guid userId { get; set;} = Guid.NewGuid();
       
        //User's first name
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        //User's last name
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public override string ToString()
        {
            return userName;
        }
        
    }
}