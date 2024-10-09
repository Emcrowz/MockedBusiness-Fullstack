using Serilog;
using Serilog.Core;
using Utilities.Constants;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile(Configurations.SETTINGS_DEV)
    .Build();

Logger log = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();
Log.Logger = log;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
