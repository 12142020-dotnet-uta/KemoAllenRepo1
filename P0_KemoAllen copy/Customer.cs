using System;

namespace P0_KemoAllen
{
    public class Customer
    {
        public Customer()
        {
            userId = Guid.NewGuid();
        }
        public Customer(string fName, string lName)
        {
            firstName = fName;
            lastName = lName;
            userId = Guid.NewGuid();

        }

        //User's id number
        private Guid userId;
        public Guid UserId
        {
            get { return userId; }
            set { userId = value; }
        }
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
        
    }
}