using Microsoft.EntityFrameworkCore;
using WebAPILinkedInLearning.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopDbContext>(options =>
{
    options.UseInMemoryDatabase("Shop");
});

// Allow CORS.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => {
        builder.AllowAnyOrigin();
        builder.WithOrigins("https://localhost:7257").WithHeaders("X-API-Version");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} else
{
    // Enforce use of HTTPS only instead of HTTP for Production environment.
    app.UseHsts(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Allow using CORS activated:
app.UseCors();

app.MapControllers();

app.Run();
