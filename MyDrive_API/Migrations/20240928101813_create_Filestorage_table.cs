using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDrive_API.Migrations
{
    /// <inheritdoc />
    public partial class create_Filestorage_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileStorageInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(16)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStorageInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileStorageInfos");
        }
    }
}
