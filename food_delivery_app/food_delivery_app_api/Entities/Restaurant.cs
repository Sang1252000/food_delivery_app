using System;
using System.Collections.Generic;

#nullable disable

namespace Food_Delivery_App_API.Entities
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            DeliveryAgents = new HashSet<DeliveryAgent>();
            Items = new HashSet<Item>();
            Orders = new HashSet<Order>();
        }

        public long RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string PhoneNumber { get; set; }
        public string RestaurantAddress { get; set; }
        public string City { get; set; }
        public string RestaurantImg { get; set; }
        public long? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<DeliveryAgent> DeliveryAgents { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
