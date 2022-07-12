using APIMovie.Application.Intefaces;
using APIMovie.Application.Services;
using APIMovie.Infrastructure.Context;
using APIMovie.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Register Configuration
ConfigurationManager configuration = builder.Configuration;
configuration.AddJsonFile("appsettings.json");
Log.Logger = new LoggerConfiguration()
        .ReadFrom
        .Configuration(configuration)
        .CreateLogger();

// Add services to the container.
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IRentalService, RentalService>();

// Add Database Service
builder.Services.AddDbContext<MovieDBContext>(option =>
    option.UseSqlServer(configuration.GetConnectionString("Default_Connection"),
    b => b.MigrationsAssembly("APIMovieWeb.API")));

//Add Logs
//builder.Host.UseSerilog();
builder.Host.UseSerilog();
builder.Services.AddLogging(logginBuilder => logginBuilder.AddSerilog(dispose: true));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
