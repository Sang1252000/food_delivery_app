using System;
using System.Collections.Generic;

#nullable disable

namespace Food_Delivery_App_API.Entities
{
    public partial class DeliveryAgent
    {
        public DeliveryAgent()
        {
            Orders = new HashSet<Order>();
        }

        public long AgentId { get; set; }
        public long? RestaurantId { get; set; }
        public string AgentName { get; set; }
        public string AgentPhone { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
