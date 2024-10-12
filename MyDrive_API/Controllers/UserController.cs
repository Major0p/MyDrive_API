using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDrive_API.Classes;
using MyDrive_API.Data_Access;
using MyDrive_API.DTOs;
using MyDrive_API.DTOs.User;
using MyDrive_API.Models.User;
using MyDrive_API.Repository.User;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace MyDrive_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]

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
            try
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    ApiResponse<UserDto> user = new();
                    user = await _userServices.GetUser(userId);
                    return HandleApiResponse(user);
                }
                else
                    return BadRequest("UserId not provide");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RemoveUser")]
        public async Task<IActionResult> RemoveUser(string userId)
        {
            try
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    ApiResponse<UserDto> user = new();
                    user = await _userServices.RemoveUser(userId);
                    return HandleApiResponse(user);
                }
                else
                    return BadRequest("UserId not provide");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserDetails userDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApiResponse<UserDto> user = new();

                    user = await _userServices.AddUser(userDetails);
                    return HandleApiResponse(user);
                }
                else
                    return BadRequest("model state is invalid, fill all details of user details");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDetails userDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApiResponse<UserDto> user = new();
                    user = await _userServices.UpdateUser(userDetails);
                    return HandleApiResponse(user);
                }
                else return BadRequest("UserDetails are not provided");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("CheckUserIdPassword")]
        public async Task<IActionResult> CheckUserIdPassword([FromBody] UserDetails userDetails)
        {
            try
            {
                if (!string.IsNullOrEmpty(userDetails.UserId) && !string.IsNullOrEmpty(userDetails.Password))
                {
                    ApiResponse<UserDto> user = new();
                    user = await _userServices.CheckUserIdPassword(userDetails);
                    return HandleApiResponse(user);
                }
                else return BadRequest("UserDetails are not provided");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}





