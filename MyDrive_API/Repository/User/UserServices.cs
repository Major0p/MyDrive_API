using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyDrive_API.Classes;
using MyDrive_API.Data_Access;
using MyDrive_API.DTOs.User;
using MyDrive_API.Models.User;

namespace MyDrive_API.Repository.User
{
    public class UserServices : IUserServices
    {
        private readonly MyDriveDBContext _dbContext;
        private readonly IMapper _mapper;

        public UserServices(MyDriveDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UserDto>> AddUser(UserDetails userDetails)
        {
            ApiResponse<UserDto> apiResponse = new();
            if (userDetails != null)
            {
                await _dbContext.Users.AddAsync(userDetails);
                await _dbContext.SaveChangesAsync();
                apiResponse.SetSuccessApiResopnse();
            }
            return apiResponse;
        }

        public async Task<ApiResponse<UserDto>> GetUser(string userId)
        {
            ApiResponse<UserDto> apiResponse = new ApiResponse<UserDto>();

            if (!string.IsNullOrEmpty(userId))
            {
                var userInfo = await _dbContext.Users.FindAsync(userId);
                if (userInfo != null)
                {
                    UserDto userDto = _mapper.Map<UserDetails, UserDto>(userInfo);
                    List<UserDto> user = new List<UserDto>();
                    user.Add(userDto);
                    apiResponse.SetSuccessApiResopnse(user);
                }
            }
            return apiResponse;
        }

        public async Task<ApiResponse<UserDto>> RemoveUser(string userId)
        {
            //remove all data related to the user 
            ApiResponse<UserDto> apiResponse = new ApiResponse<UserDto>();

            if (!string.IsNullOrEmpty(userId))
            {
                UserDetails userDetails = await _dbContext.Users.FindAsync(userId);
                if (userDetails != null)
                {
                    var toRemoveFiles = await _dbContext.FileInfos
                        .Where(fl => fl.UserId == userId)
                        .ToListAsync();

                    var toRemoveFileStorage = await _dbContext.FileStorageInfos
                        .Where(fs => fs.Id == userId)
                        .ToListAsync();

                    if (toRemoveFiles.Count > 0)
                        _dbContext.FileInfos.RemoveRange(toRemoveFiles);

                    if (toRemoveFileStorage.Count > 0)
                        _dbContext.FileStorageInfos.RemoveRange(toRemoveFileStorage);

                    _dbContext.Users.Remove(userDetails);
                    await _dbContext.SaveChangesAsync();
                    apiResponse.SetSuccessApiResopnse();
                }
            }
            return apiResponse;
        }

        public async Task<ApiResponse<UserDto>> UpdateUser(UserDetails userDetails)
        {
            ApiResponse<UserDto> apiResponse = new ApiResponse<UserDto>();

            if (userDetails != null && !string.IsNullOrEmpty(userDetails.UserId))
            {
                var existingData = await _dbContext.Users.FindAsync(userDetails.UserId);


                _dbContext.Users.Update(userDetails);
                await _dbContext.SaveChangesAsync();
                apiResponse.SetSuccessApiResopnse();
            }
            return apiResponse;
        }

        public async Task<ApiResponse<UserDto>> CheckUserIdPassword(UserDetails userDetails)
        {
            ApiResponse<UserDto> apiResponse = new ApiResponse<UserDto>();

            if (!string.IsNullOrEmpty(userDetails.UserId) && !string.IsNullOrEmpty(userDetails.Password))
            {
                //UserDetails user = await _dbContext.Users.FindAsync(userDetails.UserId);

                var user = await _dbContext.Users
                    .Where(u => u.UserId == userDetails.UserId)
                    .Select(u => new UserDetails { UserId = u.UserId, Password = u.Password })
                    .FirstOrDefaultAsync();

                if (user != null && !string.IsNullOrEmpty(user.UserId) && !string.IsNullOrEmpty(user.Password))
                {
                    apiResponse.SetSuccessApiResopnse();

                    if ((user.UserId != null && user.UserId == userDetails.UserId))
                        apiResponse.Message = "userId not found";

                    if ((user.Password != null && user.Password == userDetails.Password))
                        apiResponse.Message = "password not found";
                }
            }
            return apiResponse;
        }
    }
}



