using Food_Delivery_App_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_App_API.Repositories
{
    public interface IRestaurantOwnerRepository
    {
        void AddRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        void AddItem(Item item);
        public void DeleteItem(long itemId);
        void UpdateItem(Item itemn);
        void AddAgentDetails(DeliveryAgent deliveryAgent);
        void UpdateAgentDetails(DeliveryAgent deliveryAgent);
        List<Item> ViewMenu(long restaurantId);// Owner can able to all the items in the menu        
        Restaurant ViewRestaurantDetails(long restaurantId);
        DeliveryAgent ViewDeliveryAgentDetails(long restaurantId);
        List<Order> ViewOrderDetails(long restaurantId);
        void UpdateOrderStatus(Order order);

        Item GetItemById(long itemId);

        Order GetOrderById(long orderId);

        DeliveryAgent GetAgentById(long agentId);
    }
}
