using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MyDrive_API.Models.FileFolder
{
    public class FileDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Id", TypeName = "varchar(16)")]
        public string Id { get; set; }

        [Column("UserId", TypeName = "nvarchar(20)")]
        public string UserId { get; set; }

        [Column("FileName", TypeName = "nvarchar(max)")]
        public string FileName { get; set; }

        [Column("UploadType", TypeName = "char(8)")]
        public string UploadType { get; set; }

        [Column("FileExtension", TypeName = "nvarchar(50)")]
        public string FileExtension { get; set; }

        [Column("ParentFolder", TypeName = "varchar(16)")]
        public string ParentFolder { get; set; }

        [Column("FileSize", TypeName = "bigint")]
        public long FileSize { get; set; }

        [Column("FileRefId", TypeName = "varchar(16)")]
        public string FileRefId { get; set; }

        [Column("CreationDate", TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [Column("ModifyDate", TypeName = "datetime")]
        public DateTime ModifyDate { get; set; }

        [Column("IdPath", TypeName = "varchar(max)")]
        public string IdPath { get; set; }

        [Column("NamePath", TypeName = "nvarchar(max)")]
        public string NamePath { get; set; }

        //true and false
        [Column("Starred", TypeName = "char(8)")]
        public string Starred { get; set; }

        //true and false
        [Column("Trash", TypeName = "char(8)")]
        public string Trash { get; set; }
    }
}



