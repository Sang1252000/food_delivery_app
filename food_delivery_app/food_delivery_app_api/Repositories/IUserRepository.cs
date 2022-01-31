using Food_Delivery_App_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_App_API.Repositories
{
    public interface IUserRepository
    {
        User ValidateUser(string emailId, string password);
        void AddUser(User user);
    }
}
