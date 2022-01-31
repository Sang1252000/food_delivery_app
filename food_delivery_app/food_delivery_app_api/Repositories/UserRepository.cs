using Food_Delivery_App_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_App_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OnlineFoodDeliveryContext db;

        public UserRepository(OnlineFoodDeliveryContext db)
        {
            this.db = db;
        }

        public void AddUser(User user)
        {
            try
            {

                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User ValidateUser(string emailId, string password)
        {
            try
            {
                var users = db.Users.Where(x => x.EmailId == emailId).ToArray();
                if (users.Any(u => u.UserPassword == password))

                    return db.Users.SingleOrDefault(u => u.EmailId == emailId && u.UserPassword == password);
                else
                    return null;
                //return db.Users.SingleOrDefault(u => u.EmailId == emailId && u.UserPassword == password);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
