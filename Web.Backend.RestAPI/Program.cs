using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using Utilities.Constants;
using Web.Backend.RestAPI.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile(Configurations.SETTINGS_DEV)
    .Build();

Logger log = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();
Log.Logger = log;

builder.Services.AddDbContext<EducationDbContext>(options => options.UseSqlServer(config.GetConnectionString(Connections.EFCORE)));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if(builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(policies =>
    {
        policies.AddPolicy(Policies.CORS_ALLOWALL, policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
    });
}
else
{
    builder.Services.AddCors(policies =>
    {
        policies.AddPolicy(
            Policies.CORS_PRODUCTION, 
            policy => {
                policy.WithOrigins(@"http://localhost:7000").AllowAnyHeader().AllowAnyMethod();
            });
    });
}

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
