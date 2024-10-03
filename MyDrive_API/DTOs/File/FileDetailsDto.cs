using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyDrive_API.DTOs.File
{
    public class FileDetailsDto
    {
        public string Id { get; set; }

        public string FileName { get; set; }

        public string UploadType { get; set; }

        public string FileExtension { get; set; }

        public string ParentFolder { get; set; }

        public long FileSize { get; set; }

        public string FileRefId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public string IdPath { get; set; }

        public string NamePath { get; set; }

        //true and false
        public string Starred { get; set; }

        //true and false
        public string Trash { get; set; }

        public byte[] Data { get; set; }

    }
}
