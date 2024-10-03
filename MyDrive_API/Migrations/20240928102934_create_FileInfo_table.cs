using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDrive_API.Migrations
{
    /// <inheritdoc />
    public partial class create_FileInfo_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(16)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadType = table.Column<string>(type: "char(8)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ParentFolder = table.Column<string>(type: "varchar(16)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileRefId = table.Column<string>(type: "varchar(16)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdPath = table.Column<string>(type: "varchar(max)", nullable: false),
                    NamePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Starred = table.Column<string>(type: "char(8)", nullable: false),
                    Trash = table.Column<string>(type: "char(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileInfos");
        }
    }
}
