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
                userId = customer.userId
                //DefaultLocationId = customer.DefaultLocation.locationGuid
                //image
            };

            return customerViewModel;
        }

        public ProccessedOrderViewModel ConvertOrderToProccesedOrder(Order order)
        {
            ProccessedOrderViewModel proccessedOrder = new ProccessedOrderViewModel()
            {
                ProductName = order.orderProduct.Description,
                Quantity = order.orderQuantity,
                LocationName = order.orderLocation.LocationName,
                TotalPrice = order.getPrice()

            };

            return proccessedOrder;
        }

        
    }
}
