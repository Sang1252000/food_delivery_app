using System;
using System.Collections.Generic;

#nullable disable

namespace Food_Delivery_App_API.Entities
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Restaurants = new HashSet<Restaurant>();
        }

        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string UserPassword { get; set; }
        public string UserAddress { get; set; }
        public string City { get; set; }
        public string UserRole { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
