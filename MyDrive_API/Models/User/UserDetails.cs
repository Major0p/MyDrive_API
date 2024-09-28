using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MyDrive_API.Models.User
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("UserId", TypeName = "nvarchar(20)")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "UserId should be only 8 character")]
        public string UserId { get; set; }

        [Column("Password", TypeName = "nvarchar(20)")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password should be only 8 character")]
        public string Password { get; set; }

        [Column("Name", TypeName = "nvarchar(max)")]
        public string Name { get; set; }

        [Column("Email", TypeName = "nvarchar(20)")]
        public string Email { get; set; }

        [Column("Profile", TypeName = "varbinary(max)")]
        public byte[] Profile { get; set; }
    }
}
