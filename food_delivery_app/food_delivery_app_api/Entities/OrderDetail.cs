using System;
using System.Collections.Generic;

#nullable disable

namespace Food_Delivery_App_API.Entities
{
    public partial class OrderDetail
    {
        public long OrderDetailsId { get; set; }
        public long? OrderId { get; set; }
        public long? ItemId { get; set; }
        public decimal? ItemPrice { get; set; }
        public int? Quantity { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
