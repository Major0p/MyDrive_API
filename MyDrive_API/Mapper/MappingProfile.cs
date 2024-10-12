using AutoMapper;
using MyDrive_API.DTOs.File;
using MyDrive_API.DTOs.User;
using MyDrive_API.Models.FileFolder;
using MyDrive_API.Models.User;

namespace MyDrive_API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<UserDetails, UserDto>().ReverseMap();

            CreateMap<FileDetails, FileDetailsDto>().ReverseMap();
        }
    }
}




