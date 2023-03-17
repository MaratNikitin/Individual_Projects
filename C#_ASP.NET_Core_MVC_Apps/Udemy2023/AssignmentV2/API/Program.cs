using API.Configurations;
using API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Ensure that connection string is taken from the appsettings.json file.
builder.Services.AddDbContext<Assignment2023Context>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS
builder.Services.AddCors(option => {
    option.AddPolicy("AllowAll",
        b => b.AllowAnyHeader().
            AllowAnyOrigin().
            AllowAnyMethod());
});

// Registering AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfigurations));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
