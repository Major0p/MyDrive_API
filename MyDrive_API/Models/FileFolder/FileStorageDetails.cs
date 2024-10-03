using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyDrive_API.Models.FileFolder
{
    public class FileStorageDetails
    {
        [Key]
        [ForeignKey("Id")]
        [Column("Id", TypeName = "varchar(16)")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Column("UserId", TypeName = "nvarchar(20)")]
        public string UserId { get; set; }

        [Column("Data", TypeName = "varbinary(max)")]
        public byte[] Data { get; set; }
    }
}
