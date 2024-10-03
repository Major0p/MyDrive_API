using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyDrive_API.Classes;
using MyDrive_API.Data_Access;
using MyDrive_API.DTOs.File;
using MyDrive_API.DTOs.User;
using MyDrive_API.Models.FileFolder;

namespace MyDrive_API.Repository.FileManage
{
    public class FileServices : IFileServices
    {
        private readonly MyDriveDBContext _dbContext;   
        private readonly IMapper _mapper;
        private readonly Constants _constants;

        public FileServices(MyDriveDBContext dBContext,IMapper mapper, Constants constants)
        {
            _dbContext = dBContext; 
            _mapper = mapper;
            _constants = constants;
        }

        public async Task<ApiResponse<FileDetailsDto>> Add(FileDetailsDto fileDetailsDto)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (fileDetailsDto != null)
            {
                FileStorageDetails fileStorageDetails = _mapper.Map<FileStorageDetails>(fileDetailsDto);
                FileDetails fileDetails = _mapper.Map<FileDetails>(fileDetailsDto);
                await _dbContext.FileInfos.AddAsync(fileDetails);
                await _dbContext.FileStorageInfos.AddAsync(fileStorageDetails);
                await _dbContext.SaveChangesAsync();
                apiResponse.SetSuccessApiResopnse();
            }

            return apiResponse;
        }

        public async Task<ApiResponse<FileDetailsDto>> SetFileStarred(string id,bool isSet)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
            {
                var fileInfo = await _dbContext.FileInfos
                    .Where( fs => fs.Id == id)
                    .FirstOrDefaultAsync();

                if (fileInfo != null)
                {
                    if (isSet)
                        fileInfo.Starred = "true";
                    else
                        fileInfo.Starred = "false";

                    await _dbContext.SaveChangesAsync();
                    apiResponse.SetSuccessApiResopnse();
                }
            }

            return apiResponse;
        }

        public async Task<ApiResponse<FileDetailsDto>> SetFileToTrash(string id,bool isSet)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
            {
                var fileInfo = await _dbContext.FileInfos
                    .Where( fl => fl.Id == id)
                    .FirstOrDefaultAsync();

                if (fileInfo != null)
                {
                    if (isSet)
                    fileInfo.Trash = "true";
                    else
                        fileInfo.Trash = "false";

                    await _dbContext.SaveChangesAsync();
                    apiResponse.SetSuccessApiResopnse();
                }
            }

            return apiResponse;
        }

        public async Task<ApiResponse<FileDetailsDto>> SetFolderToTrash(string id, bool isSet)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
            {
                var fileInfo = await _dbContext.FileInfos
                    .Where(fl => fl.Id == id)
                    .FirstOrDefaultAsync();

                if (fileInfo != null)
                {
                    if (isSet)
                    fileInfo.Trash = "true";
                    else
                        fileInfo.Trash = "false";

                    await SetTrashToChilds(id);
                    await _dbContext.SaveChangesAsync();
                    apiResponse.SetSuccessApiResopnse();
                }
            }

            return apiResponse;
        }

        public async Task<ApiResponse<FileDetailsDto>> Download(string id)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
            {
                var fileInfo = await _dbContext.FileInfos
                    .Where(fl => fl.Id == id)
                    .FirstOrDefaultAsync();

                if (fileInfo != null)
                {
                    var fileStorage = await _dbContext.FileStorageInfos
                        .Where(fs => fs.Id == fileInfo.FileRefId)
                        .FirstOrDefaultAsync();

                    if (fileStorage != null)
                    {
                        FileStorageDetailsDto file = _mapper.Map<FileStorageDetailsDto>(fileStorage);
                        apiResponse.SetSuccessApiResopnse();
                    }
                }
            }
            return apiResponse;
        }

        public async Task<ApiResponse<FileDetailsDto>> GetFilesByParent(string id)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
            {
                var filesList = await _dbContext.FileInfos
                    .Where(fl=>fl.ParentFolder == id)
                    .ToListAsync();

                if (filesList.Count > 0)
                {
                    var files = _mapper.Map<List<FileDetailsDto>>(filesList);
                    apiResponse.SetSuccessApiResopnse(files);
                }
            }

            return apiResponse;
        }

        public async Task<ApiResponse<FileDetailsDto>> MoveFile(string id, string toId)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(toId))
            {
                var fileDetails = await _dbContext.FileInfos
                    .Where(fl => fl.Id == id)
                    .FirstOrDefaultAsync();

                if (fileDetails != null)
                {
                    fileDetails.ParentFolder = toId;

                    await _dbContext.SaveChangesAsync();
                    apiResponse.SetSuccessApiResopnse();
                }
            }

            return apiResponse;
        }

        public async Task<ApiResponse<FileDetailsDto>> RemoveFile(string id)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
            {
                var fileInfo = await _dbContext.FileInfos.FindAsync(id);
                var fs = await _dbContext.FileStorageInfos.FindAsync(id);

                if (fileInfo != null)
                {
                    _dbContext.FileInfos.Remove(fileInfo);
                    _dbContext.FileStorageInfos.Remove(fs);
                    await _dbContext.SaveChangesAsync();
                    apiResponse.SetSuccessApiResopnse();
                }
            }

            return apiResponse;
        }

        public async Task<ApiResponse<FileDetailsDto>> RemoveFolder(string id)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(id))
            {
                await RemoveChildren(id);

                var fileInfo = await _dbContext.FileInfos
                    .Where(fl => fl.Id == id)
                    .FirstOrDefaultAsync();
            
                _dbContext.FileInfos.Remove(fileInfo);
                await _dbContext.SaveChangesAsync();    
            }

            return apiResponse;
        }

        public async Task<ApiResponse<FileDetailsDto>> Rename(FileDetailsDto fileDetails)
        {
            ApiResponse<FileDetailsDto> apiResponse = new();

            if (!string.IsNullOrEmpty(fileDetails.Id) && !string.IsNullOrEmpty(fileDetails.FileName))
            {
                var fileInfo = await _dbContext.FileInfos
                    .Where( fs => fs.Id == fileDetails.Id)
                    .FirstOrDefaultAsync(); 

                if(fileInfo != null)
                {
                    fileInfo.FileName = fileDetails.FileName;
                    await _dbContext.SaveChangesAsync();
                    apiResponse.SetSuccessApiResopnse();
                }
            }

            return apiResponse;
        }

        public Task<ApiResponse<FileDetailsDto>> UploadFolder(FileDetailsDto fileDetailsDto)
        {
            throw new NotImplementedException();
        }

        public async Task SetTrashToChilds(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var fileInfo =  await _dbContext.FileInfos
                    .Where(fl=>fl.Id == id)
                    .FirstOrDefaultAsync();

                var childList = await _dbContext.FileInfos
                    .Where ( fl => fl.ParentFolder == id)
                    .ToListAsync();

                if (fileInfo != null && childList != null && childList.Count > 0 )
                {
                    var trash = fileInfo.Trash;
                    foreach (var child in childList)
                    {
                        child.Trash = trash;
                        
                        if(child.UploadType == _constants.FolderUploadType)
                            await SetTrashToChilds(child.Id);
                    }

                    await _dbContext.SaveChangesAsync();
                }

            }
        }

        public async Task RemoveChildren(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var fileInfo = await _dbContext.FileInfos
                    .Where(fl => fl.Id == id)
                    .FirstOrDefaultAsync();

                var childList = await _dbContext.FileInfos
                    .Where(fl => fl.ParentFolder == id)
                    .ToListAsync();

                if (fileInfo != null && childList != null && childList.Count > 0)
                {
                    foreach (var child in childList)
                    {
                        if (child != null) 
                        {
                            if (child.UploadType == _constants.FolderUploadType)
                                await RemoveChildren(child.Id);

                            var fileData = await _dbContext.FileStorageInfos
                                .Where(fs=>fs.Id == child.FileRefId)
                                .FirstOrDefaultAsync();

                             _dbContext.FileInfos.Remove(child);

                                if(fileData != null)
                            _dbContext.FileStorageInfos.Remove(fileData);
                        }
                    }

                    await _dbContext.SaveChangesAsync();
                }

            }
        }
    }
}

