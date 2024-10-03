using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDrive_API.Classes;
using MyDrive_API.Data_Access;
using MyDrive_API.DTOs;
using MyDrive_API.DTOs.User;
using MyDrive_API.Models.User;
using MyDrive_API.Repository.User;
using Newtonsoft.Json;

namespace MyDrive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        private IActionResult HandleApiResponse<T>(ApiResponse<T> response)
        {
            string jsonString = JsonConvert.SerializeObject(response);

            if (response.IsSuccess)
                return Ok(jsonString);

            return NotFound(jsonString);
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(string userId)
        {
            ApiResponse<UserDto> user = new();

            if (!string.IsNullOrEmpty(userId))
                user = await _userServices.GetUser(userId);

            return HandleApiResponse(user);
        }

        [HttpGet]
        [Route("RemoveUser")]
        public async Task<IActionResult> RemoveUser(string userId)
        {
            ApiResponse<UserDto> user = new();

            if (!string.IsNullOrEmpty(userId))
                user = await _userServices.RemoveUser(userId);

            return HandleApiResponse(user);
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(UserDetails userDetails)
        {
            ApiResponse<UserDto> user = new();

            if (ModelState.IsValid)
                user = await _userServices.AddUser(userDetails);

            return HandleApiResponse(user);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDetails userDetails)
        {
            ApiResponse<UserDto> user = new();
            
            if (ModelState.IsValid)
                user = await _userServices.UpdateUser(userDetails);
            
            return HandleApiResponse(user);
        }

        [HttpPost]
        [Route("CheckUserIdPassword")]
        public async Task<IActionResult> CheckUserIdPassword(UserDetails userDetails)
        {
            ApiResponse<UserDto> user = new();
           
            if (!string.IsNullOrEmpty(userDetails.UserId) && !string.IsNullOrEmpty(userDetails.Password))
                user = await _userServices.CheckUserIdPassword(userDetails);

            return HandleApiResponse(user);
        }
    }
}





