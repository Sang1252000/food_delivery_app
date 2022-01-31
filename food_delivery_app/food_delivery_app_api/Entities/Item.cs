using System;
using System.Collections.Generic;

#nullable disable

namespace Food_Delivery_App_API.Entities
{
    public partial class Item
    {
        public Item()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public long? RestaurantId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImg { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
