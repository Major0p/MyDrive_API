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
        public string UserId { get; set; }

        [Column("Password", TypeName = "nvarchar(20)")]
        public string Password { get; set; }

        [Column("Name", TypeName = "nvarchar(max)")]
        public string Name { get; set; }

        [Column("Email", TypeName = "nvarchar(max)")]
        public string Email { get; set; }

    }
}



