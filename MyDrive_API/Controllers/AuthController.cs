using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Services;
using MyDrive_API.Classes;
using MyDrive_API.DTOs.Auth;
using MyDrive_API.Models.Auth;
using MyDrive_API.Repository.Auth;
using Newtonsoft.Json;
using org.apache.cxf.security.claims.authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;
using System.Security.Claims;

namespace MyDrive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _Configuration;
        private readonly IUserAuthService _userAuthService;

        public AuthController(IConfiguration configuration,IUserAuthService userAuthService)
        {
            _Configuration = configuration;
            _userAuthService = userAuthService; 
        }

        private IActionResult HandleApiResponse<T>(ApiResponse<T> response)
        {
            string jsonString = JsonConvert.SerializeObject(response);

            if (response.IsSuccess)
                return Ok(jsonString);

            return NotFound(jsonString);
        }

        /*[HttpPost]
        [Route("validateUser")]
        public async Task<IActionResult> ValidateUser(LogInReqDto logInReqDto)
        {
            try
            {
                if (logInReqDto != null)
                {
                    ApiResponse<UserAuth> apiResponse = new();
                    apiResponse = await _userAuthService.ValidateIdPass(logInReqDto);
                    
                    
                }
               else
                    return BadRequest("Check Id or Name");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }*/

        /*public Task<string> GenerateJWTToken(UserAuth userAuth)
        {
            var jwtConfig = _Configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig["Key"]));
            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var Claim = new[]
            {
               new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, userAuth.UserId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, userAuth.Role)
            };


            return "";
        }*/
    }
}


