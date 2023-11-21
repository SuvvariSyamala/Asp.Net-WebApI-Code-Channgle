using Asp.Net_WebApI_Code_Channgle.DTO;
using Asp.Net_WebApI_Code_Channgle.Entitys;
using AutoMapper;

namespace Asp.Net_WebApI_Code_Channgle.Profiles
{
    public class UserProfile :Profile
    {

        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
