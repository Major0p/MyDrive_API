using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyDrive_API.DTOs.File
{
    public class FileStorageDetailsDto
    {
        public string Id { get; set; }

        public byte[] Data { get; set; }
    }
}
