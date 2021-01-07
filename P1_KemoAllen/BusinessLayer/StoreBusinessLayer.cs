using System;
using RepositoryLayer;

namespace BusinessLayer
{
    public class StoreBusinessLayer
    {
		private readonly StoreRepository _repository;
		private readonly StoreMapper _mapperClass;
		public StoreBusinessClass(StoreRepository repository, StoreMapper mapperClass)
		{
			_repository = repository;
			_mapperClass = mapperClass;
		}

		public CustomerViewModel LoginCustomer(LogInViewModel logInViewModel)
        {

        }

		public CustomerViewModel EditCustomer(Guid customerId)
        {
			
        }

		public CustomerViewModel EditedCustomer(CustomerViewModel customerViewModel)
        {

        }


	}
}
