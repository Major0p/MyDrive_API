using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MyDrive_API.DTOs.User
{
    public class UserDto
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

    }
}


