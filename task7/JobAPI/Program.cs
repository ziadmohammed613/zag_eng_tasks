using JobAPI.Data;
using Microsoft.EntityFrameworkCore;
using JobAPI.Services;
using JobAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddDbContext<AppDbContext>(builder => builder.UseSqlServer("Data Source=DESKTOP-HU0LKOG\\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0;DataBase=JobListing"));

var app = builder.Build();

app.UseMiddleware<LogRequestMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();
// maps route to application controllers

app.UseAuthorization();
// check user authorization

app.MapControllers();

app.Run();
