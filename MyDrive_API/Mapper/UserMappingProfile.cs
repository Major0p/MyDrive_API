using AutoMapper;
using MyDrive_API.DTOs.User;
using MyDrive_API.Models.User;

namespace MyDrive_API.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() {
            CreateMap<UserDetails, UserDto>();
            CreateMap<UserDto, UserDetails>();
        }
    }
}

