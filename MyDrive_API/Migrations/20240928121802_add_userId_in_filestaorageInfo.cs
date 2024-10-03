using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDrive_API.Migrations
{
    /// <inheritdoc />
    public partial class add_userId_in_filestaorageInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FileStorageInfos",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FileStorageInfos");
        }
    }
}
