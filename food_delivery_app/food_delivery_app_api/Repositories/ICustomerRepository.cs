using Food_Delivery_App_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Food_Delivery_App_API.Repositories
{
    public interface ICustomerRepository
    {
        List<Restaurant> ViewAllRestaraunts();
        List<Restaurant> ViewAllRestarauntsByCity(string City);
        Restaurant SearchRestarauntByName(string ResturantName);

        void PlaceOrder(Order order);
        int CancelOrder(long OrderId);
        List<Order> ViewOrdersOfCustomer(long UserId);
        List<Order> OrderStatus(long UserId);
        void UpdateCustomerDetails(User user);

        
        //Logout Function
    }
}
