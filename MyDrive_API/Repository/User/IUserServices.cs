using Microsoft.AspNetCore.Mvc;
using MyDrive_API.Classes;
using MyDrive_API.DTOs.User;
using MyDrive_API.Models.User;

namespace MyDrive_API.Repository.User
{
    public interface IUserServices
    {
        public Task<ApiResponse<UserDto>> AddUser(UserDetails userDetails);

        public Task<ApiResponse<UserDto>> RemoveUser(string userId);

        public Task<ApiResponse<UserDto>> GetUser(string userId);

        public Task<ApiResponse<UserDto>> UpdateUser(UserDetails userDetails);

        public Task<ApiResponse<UserDto>> CheckUserIdPassword(UserDetails userDetails);
    }
}

