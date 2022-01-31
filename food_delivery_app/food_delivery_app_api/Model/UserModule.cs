using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_App_API.Model
{
    public class UserModule
    {
        public long UserId { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
