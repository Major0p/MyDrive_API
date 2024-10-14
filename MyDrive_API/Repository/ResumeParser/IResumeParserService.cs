using MyDrive_API.Classes;
using MyDrive_API.Models.FileFolder;

namespace MyDrive_API.Repository.ResumeParser
{
    public interface IResumeParserService
    {
        public Task<ApiResponse<FileStorageDetails>> GetFileById(string id);

        public ApiResponse<string> GetTextFromFile(FileStorageDetails fileStorageDetails);

    }
}


