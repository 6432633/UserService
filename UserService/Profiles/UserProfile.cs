using AutoMapper;
using UserService.DTO;
using UserService.Models;

namespace UserService.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTo, User>();
            CreateMap<User, UserUpdateDTo>();
        }
    }
}
