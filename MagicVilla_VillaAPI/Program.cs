using Serilog;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

string logFile = "log/villaLog.txt";
Log.Logger = new LoggerConfiguration().MinimumLevel.Warning().WriteTo.File(logFile, rollingInterval: RollingInterval.Day ).CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers(option =>
    {
        //option.ReturnHttpNotAcceptable = true;
    }
).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

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
