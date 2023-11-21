using Asp.Net_WebApI_Code_Channgle.Database;
using Asp.Net_WebApI_Code_Channgle.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_WebApI_Code_Channgle.Services
{
    public class UserService :IUserService
    {
        
            private readonly ChallengeContext Context= null;

            public UserService(ChallengeContext context)
            {
                this.Context = context;
            }

        public void AddUser(User user)
        {
            try
            {
                Context.Users.Add(user);
                Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {

                if (user != null)
                {
                    Context.Users.Update(user);
                    Context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public User ValidteUser(string email, string password)
        {
            return Context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
