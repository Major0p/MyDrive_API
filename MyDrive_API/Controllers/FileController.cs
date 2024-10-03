using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDrive_API.Classes;
using MyDrive_API.DTOs.File;
using MyDrive_API.Repository.FileManage;
using Newtonsoft.Json;

namespace MyDrive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        [Route("Rename")]
        public async Task<IActionResult> Rename(FileDetailsDto fileDetailsDto)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(fileDetailsDto.Id) && !string.IsNullOrEmpty(fileDetailsDto.FileName))
                apiResponse = await _fileServices.Rename(fileDetailsDto);

            return HandleApiResponse(apiResponse);
        }

        [HttpPatch]
        [Route("SetFileToTrash")]
        public async Task<IActionResult> SetFileToTrash(string id, string isSet)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
                apiResponse = await _fileServices.SetFileToTrash(id, bool.Parse(isSet));

            return HandleApiResponse(apiResponse);
        }

        [HttpPatch]
        [Route("SetFolderToTrash")]
        public async Task<IActionResult> SetFolderToTrash(string id, string isSet)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
                apiResponse = await _fileServices.SetFolderToTrash(id, bool.Parse(isSet));

            return HandleApiResponse(apiResponse);
        }

        [HttpGet]
        [Route("RemoveFolder")]
        public async Task<IActionResult> RemoveFolder(string id)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
                apiResponse = await _fileServices.RemoveFolder(id);

            return HandleApiResponse(apiResponse);
        }

        [HttpGet]
        [Route("RemoveFile")]
        public async Task<IActionResult> RemoveFile(string id)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
                apiResponse = await _fileServices.RemoveFolder(id);

            return HandleApiResponse(apiResponse);
        }

        [HttpPatch]
        [Route("SetFileStarred")]
        public async Task<IActionResult> SetFileStarred(string id,string isSet)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
                apiResponse = await _fileServices.SetFileStarred(id,bool.Parse(isSet));

            return HandleApiResponse(apiResponse);
        }

        [HttpGet]
        [Route("GetFilesByParent")]
        public async Task<IActionResult> GetFilesByParent(string id)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
                apiResponse = await _fileServices.GetFilesByParent(id);

            return HandleApiResponse(apiResponse);
        }

        [HttpPatch]
        [Route("MoveFile")]
        public async Task<IActionResult> MoveFile(string id,string toId)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
                apiResponse = await _fileServices.MoveFile(id, toId);

            return HandleApiResponse(apiResponse);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(FileDetailsDto fileDetailsDto)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (ModelState.IsValid)
                apiResponse = await _fileServices.Add(fileDetailsDto);

            return HandleApiResponse(apiResponse);  
        }

        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> Download(string id)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
            {
                apiResponse = await _fileServices.Download(id);

                if(apiResponse.IsSuccess && apiResponse.Data.Count > 0)
                {
                    var fileDetail = apiResponse.Data[0];

                    return File(fileDetail.Data,"application/octet-stream",fileDetail.FileName);
                }
            }

            return HandleApiResponse(apiResponse);
        }
    }
}

