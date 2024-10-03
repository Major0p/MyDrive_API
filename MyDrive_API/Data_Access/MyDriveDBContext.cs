using Microsoft.EntityFrameworkCore;
using MyDrive_API.Models.FileFolder;
using MyDrive_API.Models.User;

namespace MyDrive_API.Data_Access
{
    public class MyDriveDBContext : DbContext
    {
        public MyDriveDBContext(DbContextOptions<MyDriveDBContext> options) : base(options) {}
    
        public DbSet<UserDetails> Users { get; set; }  

        public DbSet<FileDetails> FileInfos { get; set; }

        public DbSet<FileStorageDetails> FileStorageInfos { get; set; }

    }
}


