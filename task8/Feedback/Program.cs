using Feedback.Options;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.Configure<SystemSettingsOptions>(builder.Configuration.GetSection("SystemSettings"));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
