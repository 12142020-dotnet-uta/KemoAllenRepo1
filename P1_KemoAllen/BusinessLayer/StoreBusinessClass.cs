using System;
using System.Collections.Generic;
using ModelLayer.ViewModels;
using RepositoryLayer;
using ModelLayer;

namespace BusinessLayer
{
    public class StoreBusinessClass
    {
        private readonly StoreRepository _repository;
        private readonly StoreMapper _mapper;

        //public StoreBusinessClass()
        //{
        //}

        public StoreBusinessClass(StoreRepository storeRepository, StoreMapper storeMapper)
        {
            _repository = storeRepository;
            _mapper = storeMapper;
        }
        /// <summary>
        /// Logs in a user. Converts the loginView into a customerView
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        public CustomerViewModel LoginCustomer(LoginViewModel loginViewModel)
        {
            Customer customer = new Customer()
            {
                UserName = loginViewModel.UserName
            };

            Customer customer1 = _repository.LoginCustomer(customer);

            CustomerViewModel customerViewModel = _mapper.CovertCustomerToCustomerViewModel(customer1);

            return customerViewModel;
        }

        public CustomerViewModel RegisterCustomer(RegisterViewModel registerViewModel)
        {
            Customer customer = new Customer()
            {
                UserName = registerViewModel.UserName,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Password = registerViewModel.Password
            };

            Customer customer1 = _repository.RegisterCustomer(customer);

            CustomerViewModel customerViewModel = _mapper.CovertCustomerToCustomerViewModel(customer1);

            return customerViewModel;
        }

        public CustomerViewModel GetCustomer(Guid customerId)
        {
            Customer customer = _repository.GetCustomerById(customerId);

            CustomerViewModel customerViewModel = _mapper.CovertCustomerToCustomerViewModel(customer);

            return customerViewModel;
        }

        public CustomerViewModel RecievedCustomer(CustomerViewModel customerViewModel)
        {
            Customer customer = _repository.GetCustomerById(customerViewModel.userId);

            customer.FirstName = customerViewModel.FirstName;
            customer.LastName = customerViewModel.LastName;
            customer.UserName = customerViewModel.UserName;

            Customer customer1 = _repository.EditCustomer(customer);
            CustomerViewModel customerView = _mapper.CovertCustomerToCustomerViewModel(customer1);
            return customerView;
        }


        public List<CustomerViewModel> CustomerList()
        {
            //call repo to get list
            List<Customer> customerList = _repository.GetCustomers();

            //convert list<player> to list<playerviewmodel>
            List<CustomerViewModel> customerViewModelList = new List<CustomerViewModel>();
            foreach (Customer cust in customerList)
            {
                customerViewModelList.Add(_mapper.CovertCustomerToCustomerViewModel(cust));
            }

            return customerViewModelList;
        }

        public CustomerViewModel EditCustomer(Guid userId)
        {
            // call a method in Repository that will return a customer based on his Id.
            Customer customer = _repository.GetCustomerById(userId);

            // map the player to a PlayerViewModel
            CustomerViewModel playerViewModel = _mapper.CovertCustomerToCustomerViewModel(customer);

            return playerViewModel;

        }

        public CustomerViewModel EditedCustomer(CustomerViewModel customerViewModel)
        {
            // get an instance of the player being edited.
            Customer customer = _repository.GetCustomerById(customerViewModel.userId);

            customer.userId = customerViewModel.userId;
            customer.FirstName = customerViewModel.FirstName;
            customer.LastName = customerViewModel.LastName;
            customer.UserName = customerViewModel.UserName;

            //customer.ByteArrayImage = _mapperClass.ConvertIformFileToByteArray(customerViewModel.IformFileImage);  //call the mapper class method ot convert the iformfile to byte[]

            Customer customer1 = _repository.EditCustomer(customer);
            CustomerViewModel playerViewModel1 = _mapper.CovertCustomerToCustomerViewModel(customer1);
            return customerViewModel;
        }

        public bool CheckUserExists(Guid userId)
        {
            bool exists = _repository.CheckUserExists(userId);

            return exists;
        }

        public bool DeleteCustomerById(Guid customerId)
        {
            bool success = _repository.DeleteCustomerById(customerId);

            return success;
        }






    }
}
