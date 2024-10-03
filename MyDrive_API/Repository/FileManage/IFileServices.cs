using MyDrive_API.Classes;
using MyDrive_API.DTOs.File;
using MyDrive_API.Models.FileFolder;

namespace MyDrive_API.Repository.FileManage
{
    public interface IFileServices
    {
        public Task<ApiResponse<FileDetailsDto>> UploadFolder(FileDetailsDto fileDetailsDto);

        public Task<ApiResponse<FileDetailsDto>> Rename(FileDetailsDto fileDetailsDto);

        public Task<ApiResponse<FileDetailsDto>> Add(FileDetailsDto fileDetailsDto);

        public Task<ApiResponse<FileDetailsDto>> Download(string id);

        public Task<ApiResponse<FileDetailsDto>> SetFileToTrash(string id,bool isSet);

        public Task<ApiResponse<FileDetailsDto>> SetFolderToTrash(string id, bool isSet);

        public Task<ApiResponse<FileDetailsDto>> RemoveFolder(string id);

        public Task<ApiResponse<FileDetailsDto>> RemoveFile(string id);

        public Task<ApiResponse<FileDetailsDto>> SetFileStarred(string id,bool isSet);

        public Task<ApiResponse<FileDetailsDto>> GetFilesByParent(string id);

        public Task<ApiResponse<FileDetailsDto>> MoveFile(string id, string toId);

    }
}


