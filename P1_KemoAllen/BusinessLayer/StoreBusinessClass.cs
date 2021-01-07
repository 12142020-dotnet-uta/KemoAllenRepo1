using System;
using System.Collections.Generic;
using ModelLayer.ViewModels;
using RepositoryLayer;

namespace BusinessLayer
{
    public class StoreBusinessClass
    {
        public StoreBusinessClass()
        {
        }
        public StoreBusinessClass(StoreRepository storeRepository, StoreMapper storeMapper)
        {
        }

        public List<CustomerViewModel> CustomerList()
        {
            //call repo to get list

            //convert list<player> to list<playerviewmodel>
            List<CustomerViewModel> customerViewModel = new List<CustomerViewModel>();
            foreach(CustomerViewModel cust in customers)
            {
                customerViewModel.Add();
            }
        }

    }
}
