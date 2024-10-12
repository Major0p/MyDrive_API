using Microsoft.EntityFrameworkCore;
using MyDrive_API.Data_Access;
using MyDrive_API.Mapper;
using MyDrive_API.Repository.User;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using MyDrive_API.Repository.FileManage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


// Add services to the container.

var config = builder.Configuration;
var MyDriveDBCS = config.GetConnectionString("MyDriveDBCS");

builder.Services.AddDbContext<MyDriveDBContext>(item => item.UseSqlServer(MyDriveDBCS));
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IFileServices, FileServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
