using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using Utilities.Constants;
using Web.Backend.Domain.Data;
using Web.Backend.Domain.Repositories;
using Web.Backend.Domain.Repositories.Contracts;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile(Configurations.SETTINGS_DEV)
    .Build();

// Serilog
Logger log = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();
Log.Logger = log;

// EFCore
string? connectionString = config.GetConnectionString(Connections.POSTGRES);
builder.Services.AddDbContext<EducationDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    // CORS
    builder.Services.AddCors(policies =>
    {
        policies.AddPolicy(Policies.CORS_ALLOWALL, policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
    });
}
else
{
    // CORS
    builder.Services.AddCors(policies =>
    {
        policies.AddPolicy(
            Policies.CORS_PRODUCTION,
            policy =>
            {
                policy.WithOrigins(@"http://localhost:7000").AllowAnyHeader().AllowAnyMethod();
            });
    });
}

builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
