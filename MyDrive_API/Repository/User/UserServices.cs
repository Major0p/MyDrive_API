using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyDrive_API.Data_Access;
using MyDrive_API.DTOs.User;
using MyDrive_API.Models.User;
using System.Linq;

namespace MyDrive_API.Repository.User
{
    public class UserServices : IUserServices
    {
        private readonly MyDriveDBContext _dbContext;
        private readonly IMapper _mapper;

        public UserServices(MyDriveDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> AddUser(UserDetails userDetails)
        {
            UserDto userDto = new UserDto();
            if (userDetails != null)
            {
                await _dbContext.Users.AddAsync(userDetails);
                await _dbContext.SaveChangesAsync();
                _mapper.Map<UserDetails, UserDto>(userDetails);
            }
            return userDto;
        }

        public async Task<UserDto> GetUser(string userId)
        {
            UserDto userDto = new UserDto();
            if (!string.IsNullOrEmpty(userId))
            {
                var userInfo = await _dbContext.Users.FindAsync(userId);
                if (userInfo != null)
                    userDto = _mapper.Map<UserDetails, UserDto>(userInfo);
            }
            return userDto;
        }

        public async Task<UserDto> RemoveUser(string userId)
        {
            UserDto userDto = new UserDto();
            if (!string.IsNullOrEmpty(userId))
            {
                UserDetails userDetails = await _dbContext.Users.FindAsync(userId);
                if (userDetails != null)
                {
                    userDto = _mapper.Map<UserDetails, UserDto>(userDetails);
                    _dbContext.Users.Remove(userDetails);
                    await _dbContext.SaveChangesAsync();
                }
            }
            return userDto;
        }

        public async Task<UserDto> UpdateUser(UserDetails userDetails)
        {
            UserDto userDto = new UserDto();
            if (userDetails != null && !string.IsNullOrEmpty(userDetails.UserId) )
            {
                var existingData = await _dbContext.Users.FindAsync(userDetails.UserId);
                
                
                    _dbContext.Users.Update(userDetails);

                await _dbContext.SaveChangesAsync();
                _mapper.Map<UserDetails, UserDto>(userDetails);
            }
            return userDto;
        }

        public async Task<object> CheckUserIdPassword(UserDetails userDetails)
        {
            if (!string.IsNullOrEmpty(userDetails.UserId) && !string.IsNullOrEmpty(userDetails.Password))
            {
                //UserDetails user = await _dbContext.Users.FindAsync(userDetails.UserId);

                var user = await _dbContext.Users
                    .Where(u => u.UserId == userDetails.UserId)
                    .Select(u => new UserDetails { UserId = u.UserId, Password = u.Password })
                    .FirstOrDefaultAsync();

                if (user != null)
                {
                    bool hasUser = false;
                    bool hasPassword = false;   
                    if (user.UserId != null && user.UserId == userDetails.UserId)
                        hasUser = true;
                    if (user.Password != null && user.Password == userDetails.Password)
                        hasPassword = true;
                    return new {id = hasUser,password= hasPassword };
                }
            }
            return new { id = false, passoword = false };
        }
    }
}



