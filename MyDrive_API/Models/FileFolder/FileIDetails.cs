using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MyDrive_API.Models.FileFolder
{
    public class FileIDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Id", TypeName = "varchar(16)")]
        public string Id { get; set; }
        //yymmddhhmmssmsrn (2409251318232389)

        [Column("UserId", TypeName = "nvarchar(20)")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "UserId should be only 8 character")]
        [Required]
        [NotNull]
        public string UserId { get; set; }

        [Required]
        [NotNull]
        [Column("FileName", TypeName = "nvarchar(max)")]
        public string FileName { get; set; }

        [Required]
        [Column("UploadType", TypeName = "char(2)")]
        [NotNull]
        public string UploadType { get; set; }

        [Column("FileExtension", TypeName = "nvarchar(50)")]
        public string FileExtension { get; set; }

        [NotNull]
        [Column("ParentFolder", TypeName = "varchar(16)")]
        public string ParentFolder { get; set; }

        [Column("FileSize", TypeName = "bigint")]
        public string FileSize { get; set; }

        [Column("FileRefId", TypeName = "varchar(16)")]
        public string FileRefId { get; set; }

        [Column("CreationDate", TypeName = "DateTime")]
        public DateTime CreationDate { get; set; }

        [Column("CreationDate", TypeName = "DateTime")]
        public DateTime ModifyDate { get; set; }

        [Column("IdPath", TypeName = "varchar(max)")]
        public string IdPath { get; set; }

        [Column("NamePath", TypeName = "nvarchar(max)")]
        public string NamePath { get; set; }

        //true and false
        [Column("Starred", TypeName = "char(5)")]
        public string Starred { get; set; }

        //true and false
        [Column("Trash", TypeName = "char(5)")]
        public string Trash { get; set; }
    }
}
