using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using com.beust.jcommander.@internal;

namespace MyDrive_API.DTOs.File
{
    public class FileDetailsDto
    {
        public string UserId { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public string UploadType { get; set; } = string.Empty;

        public string FileExtension { get; set; } = string.Empty;

        public string ParentFolder { get; set; } = string.Empty;

        public long FileSize { get; set; } = 0;

        public string FileRefId { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime ModifyDate { get; set; } = DateTime.UtcNow;

        public string IdPath { get; set; } = string.Empty;

        public string NamePath { get; set; } = string.Empty;

        //true and false
        public string Starred { get; set; } = "false";

        //true and false
        public string Trash { get; set; } = "false";

        public byte[] Data { get; set; } = [];

        public IFormFile? File { get; set; } = null;
    }
}



