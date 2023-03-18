using AutoMapper;
using HotelListingAPI.Configurations;
using HotelListingAPI.Contracts;
using HotelListingAPI.Data;
using HotelListingAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HotelListingDbConnectionString");
builder.Services.AddDbContext<HotelDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors(option => {
    option.AddPolicy("AllowAll", 
        b => b.AllowAnyHeader().
            AllowAnyOrigin().
            AllowAnyMethod());
});

builder.Host.UseSerilog((context, loggerConfiguration) => {
    loggerConfiguration.WriteTo.Console().ReadFrom.Configuration(context.Configuration);
});

// Registering AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

// Injections for using the repository pattern
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
