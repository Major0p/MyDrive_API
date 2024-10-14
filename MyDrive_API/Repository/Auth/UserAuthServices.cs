using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyDrive_API.Classes;
using MyDrive_API.Data_Access;
using MyDrive_API.DTOs.Auth;
using MyDrive_API.Models.Auth;

namespace MyDrive_API.Repository.Auth
{
    public class UserAuthServices : IUserAuthService
    {
        private readonly MyDriveDBContext _dbContext;
        private readonly IMapper _mapper;

        public UserAuthServices(MyDriveDBContext dBContext,IMapper mapper)
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UserAuth>> ValidateIdPass(LogInReqDto logInReqDto)
        {
            ApiResponse<UserAuth> apiResponse = new();
            if (!string.IsNullOrEmpty(logInReqDto.UserId) && !string.IsNullOrEmpty(logInReqDto.Password))
            {
                var user = await _dbContext.Users.AsNoTracking().Where(u => u.UserId == logInReqDto.UserId).Select(u => new { UserId = u.UserId, Password = u.Password }).FirstOrDefaultAsync();
                if (!string.IsNullOrEmpty(user.UserId) && !string.IsNullOrEmpty(user.Password))
                {
                    if (user.UserId == logInReqDto.UserId && user.Password == logInReqDto.Password)
                        apiResponse.SetSuccessApiResopnse();
                }
            }
            return apiResponse;
        }


    }
}



