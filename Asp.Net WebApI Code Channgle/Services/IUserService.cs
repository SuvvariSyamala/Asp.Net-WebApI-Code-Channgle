using Asp.Net_WebApI_Code_Channgle.Entitys;

namespace Asp.Net_WebApI_Code_Channgle.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        void UpdateUser(User user);

         User ValidteUser(string email, string password);

    }
}
