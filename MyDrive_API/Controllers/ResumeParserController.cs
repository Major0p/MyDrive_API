using javax.ws.rs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDrive_API.Classes;
using MyDrive_API.Models.FileFolder;
using MyDrive_API.Repository.ResumeParser;
using Newtonsoft.Json;

namespace MyDrive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeParserController : ControllerBase
    {
        public readonly IResumeParserService _resumeParserService;
        public ResumeParserController(IResumeParserService resumeParserService)
        {
            _resumeParserService = resumeParserService;
        }
        private IActionResult HandleApiResponse<T>(ApiResponse<T> response)
        {
            string jsonString = JsonConvert.SerializeObject(response);

            if (response.IsSuccess)
                return Ok(jsonString);

            return NotFound(jsonString);
        }

        [HttpGet]
        [Route("GetPdfString")]
        public async Task<IActionResult> GetTextFromFile(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ApiResponse<string> apiResponse = new();
                    ApiResponse<FileStorageDetails> fileRes = await _resumeParserService.GetFileById(id);
                    if (fileRes != null && fileRes.Data.Count > 0)
                    {
                        apiResponse = _resumeParserService.GetTextFromFile(fileRes.Data[0]);
                        return HandleApiResponse(apiResponse);
                    }
                    return BadRequest("file data not found");
                }
                else
                    return BadRequest("Check Id");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}





