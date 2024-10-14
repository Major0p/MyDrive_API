using MyDrive_API.Classes;
using MyDrive_API.DTOs.Auth;
using MyDrive_API.Models.Auth;
using MyDrive_API.Models.User;

namespace MyDrive_API.Repository.Auth
{
    public interface IUserAuthService
    {
        public Task<ApiResponse<UserAuth>> ValidateIdPass(LogInReqDto logInReqDto); 
    }
}
