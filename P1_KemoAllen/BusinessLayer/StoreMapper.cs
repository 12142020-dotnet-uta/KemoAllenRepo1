using System;
using ModelLayer;
using ModelLayer.ViewModels;
namespace BusinessLayer
{
    public class StoreMapper
    {
        public StoreMapper()
        {
        }

        public CustomerViewModel CovertCustomerToCustomerViewModel(Customer customer)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                UserName = customer.UserName,
                //image
            };

            return customerViewModel;
        }

        //public RegisterViewModel ConvertCustomerToRegisterViewModel(Customer customer)
        //{
        //    RegisterViewModel registerViewModel = new RegisterViewModel()
        //    {
        //        FirstName = customer.FirstName,
        //        LastName = customer.LastName,
        //        UserName = customer.UserName,
        //        Password = customer.Password
        //        //image
        //    };

        //    return registerViewModel;
        //}

        
    }
}
