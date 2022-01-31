using System;
using System.Collections.Generic;

#nullable disable

namespace Food_Delivery_App_API.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long OrderId { get; set; }
        public long? RestaurantId { get; set; }
        public long? AgentId { get; set; }
        public long? UserId { get; set; }
        public string PaymentMode { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual DeliveryAgent Agent { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
