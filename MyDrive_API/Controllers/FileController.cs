using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDrive_API.Classes;
using MyDrive_API.DTOs.File;
using MyDrive_API.Repository.FileManage;
using Newtonsoft.Json;

namespace MyDrive_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class FileController : ControllerBase
    {
        private readonly IFileServices _fileServices;

        public FileController(IFileServices fileServices)
        {
            _fileServices = fileServices;
        }

        private IActionResult HandleApiResponse<T>(ApiResponse<T> response)
        {
            string jsonString = JsonConvert.SerializeObject(response);

            if (response.IsSuccess)
                return Ok(jsonString);

            return NotFound(jsonString);
        }

        [HttpPatch]
        [Route("Rename")]
        public async Task<IActionResult> Rename(string id, string NewName)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(NewName))
                {
                    ApiResponse<FileDetailsDto> apiResponse = new();
                    apiResponse = await _fileServices.Rename(id, NewName);

                    return HandleApiResponse(apiResponse);
                }
                else
                    return BadRequest("Check Id or Name");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("SetFileToTrash")]
        public async Task<IActionResult> SetFileToTrash(string id, string isSet)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ApiResponse<FileDetailsDto> apiResponse = new();
                    apiResponse = await _fileServices.SetFileToTrash(id, bool.Parse(isSet));

                    return HandleApiResponse(apiResponse);
                }
                else
                    return BadRequest("Id not provide");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("SetFolderToTrash")]
        public async Task<IActionResult> SetFolderToTrash(string id, string isSet)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ApiResponse<FileDetailsDto> apiResponse = new();
                    apiResponse = await _fileServices.SetFolderToTrash(id, bool.Parse(isSet));
                    return HandleApiResponse(apiResponse);
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
        [Route("RemoveFolder")]
        public async Task<IActionResult> RemoveFolder(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ApiResponse<FileDetailsDto> apiResponse = new();
                    apiResponse = await _fileServices.RemoveFolder(id);
                    return HandleApiResponse(apiResponse);
                }
                else
                    return BadRequest("Id not provide");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RemoveFile")]
        public async Task<IActionResult> RemoveFile(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ApiResponse<FileDetailsDto> apiResponse = new();
                    apiResponse = await _fileServices.RemoveFolder(id);
                    return HandleApiResponse(apiResponse);
                }
                else
                    return BadRequest("UserId not provide");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("SetFileStarred")]
        public async Task<IActionResult> SetFileStarred(string id, string isSet)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ApiResponse<FileDetailsDto> apiResponse = new();
                    apiResponse = await _fileServices.SetFileStarred(id, bool.Parse(isSet));
                    return HandleApiResponse(apiResponse);
                }
                else
                    return BadRequest("id not provide");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetFilesByParent")]
        public async Task<IActionResult> GetFilesByParent(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ApiResponse<FileDetailsDto> apiResponse = new();
                    apiResponse = await _fileServices.GetFilesByParent(id);
                    return HandleApiResponse(apiResponse);
                }
                else
                    return BadRequest("UserId not provide");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("MoveFile")]
        public async Task<IActionResult> MoveFile(string id, string toId)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ApiResponse<FileDetailsDto> apiResponse = new();
                    apiResponse = await _fileServices.MoveFile(id, toId);
                    return HandleApiResponse(apiResponse);
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
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] FileDetailsDto fileDetailsDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApiResponse<FileDetailsDto> apiResponse = new();
                    apiResponse = await _fileServices.Add(fileDetailsDto);
                    return HandleApiResponse(apiResponse);
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
        [Route("Download")]
        public async Task<IActionResult> Download(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ApiResponse<FileDetailsDto> apiResponse = new();
                    apiResponse = await _fileServices.Download(id);

                    if (apiResponse.IsSuccess && apiResponse.Data.Count > 0)
                    {
                        var fileDetail = apiResponse.Data[0];

                        return File(fileDetail.Data, "application/octet-stream", fileDetail.FileName);
                    }
                    return HandleApiResponse(apiResponse);

                }
                else
                    return BadRequest("UserId not provide");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

