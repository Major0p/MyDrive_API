using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
       /* private readonly IUserServices _userServices;
        
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
               Task<UserDto> user = _userServices.GetUser(userId);
                if (user != null)
                {
                    string jsonStr = JsonConvert.SerializeObject(user);
                    return Ok(jsonStr);
                }
            }
            return NotFound("failed to get user");
        }

        [HttpGet]
        [Route("RemoveUser")]
        public IActionResult RemoveUser(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var user = _userServices.RemoveUser(userId);
                if (user != null)
                {
                    string jsonStr = JsonConvert.SerializeObject(user);
                    return Ok(jsonStr);
                }
            }
            return NotFound("failed to rmove user");
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                var user = _userServices.AddUser(userDetails);
                if (user != null)
                {
                    var jsonStr = JsonConvert.SerializeObject(user);
                    return Ok(jsonStr);
                }
            }
            return NotFound("failed to add user");  
        }

        [HttpPost]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                var user = _userServices.UpdateUser(userDetails);
                if (user != null)
                {
                    var jsonStr = JsonConvert.SerializeObject(user);
                    return Ok(jsonStr);
                }
            }
            return NotFound("failed to update user");
        }

        [HttpPost]
        [Route("CheckUserIdPassword")]
        public IActionResult CheckUserIdPassword(UserDetails userDetails)
        {
            if (!string.IsNullOrEmpty(userDetails.UserId) && !string.IsNullOrEmpty(userDetails.Password))
            {
                var user = _userServices.CheckUserIdPassword(userDetails);
                if (user!= null)
                {
                    var jsonStr = JsonConvert.SerializeObject(user);
                    return Ok(jsonStr);
                }
            }
            return NotFound("failed to check userid and password");
        }
*/
    }
}



