using Microsoft.EntityFrameworkCore;
using MyDrive_API.Data_Access;
using MyDrive_API.Mapper;
using MyDrive_API.Repository.User;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using MyDrive_API.Repository.FileManage;
using MyDrive_API.Repository.ResumeParser;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
builder.Services.AddScoped<IResumeParserService, ResumeParserServices>();

//jwt auth
var key = Encoding.ASCII.GetBytes(config.GetSection("Jwt")["key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;//set true in production
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config.GetSection("jwt")["Issuare"],
            ValidAudience = config.GetSection("jwt")["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
        };

    });

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


