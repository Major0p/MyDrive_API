﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyDrive_API.Data_Access;

#nullable disable

namespace MyDrive_API.Migrations
{
    [DbContext(typeof(MyDriveDBContext))]
    [Migration("20241006093442_remove_profile_Store")]
    partial class remove_profile_Store
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyDrive_API.Models.FileFolder.FileDetails", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(16)")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreationDate");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FileExtension");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FileName");

                    b.Property<string>("FileRefId")
                        .IsRequired()
                        .HasColumnType("varchar(16)")
                        .HasColumnName("FileRefId");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint")
                        .HasColumnName("FileSize");

                    b.Property<string>("IdPath")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("IdPath");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime")
                        .HasColumnName("ModifyDate");

                    b.Property<string>("NamePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NamePath");

                    b.Property<string>("ParentFolder")
                        .IsRequired()
                        .HasColumnType("varchar(16)")
                        .HasColumnName("ParentFolder");

                    b.Property<string>("Starred")
                        .IsRequired()
                        .HasColumnType("char(8)")
                        .HasColumnName("Starred");

                    b.Property<string>("Trash")
                        .IsRequired()
                        .HasColumnType("char(8)")
                        .HasColumnName("Trash");

                    b.Property<string>("UploadType")
                        .IsRequired()
                        .HasColumnType("char(8)")
                        .HasColumnName("UploadType");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("FileInfos");
                });

            modelBuilder.Entity("MyDrive_API.Models.FileFolder.FileStorageDetails", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(16)")
                        .HasColumnName("Id");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Data");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("FileStorageInfos");
                });

            modelBuilder.Entity("MyDrive_API.Models.User.UserDetails", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UserId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
