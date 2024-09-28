using Microsoft.AspNetCore.Mvc;
using MyDrive_API.DTOs.User;
using MyDrive_API.Models.User;

namespace MyDrive_API.Repository.User
{
    public interface IUserServices
    {
        public Task<UserDto> AddUser(UserDetails userDetails);

        public Task<UserDto> RemoveUser(string userId);

        public Task<UserDto> GetUser(string userId);

        public Task<UserDto> UpdateUser(UserDetails userDetails);

        public Task<object> CheckUserIdPassword(UserDetails userDetails);
    }
}

