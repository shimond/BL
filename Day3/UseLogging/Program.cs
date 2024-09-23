using Serilog;
using UseLogging.Contracts;
using UseLogging.Services;

var builder = WebApplication.CreateBuilder(args);

var url = builder.Configuration["seq"];

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties} {Scope}{NewLine}{Exception}")
    .WriteTo.Seq(url)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddHttpLogging(x => x.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All);

var app = builder.Build();
app.UseHttpLogging();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/", (IMyService service, ILogger<Program> logger) =>
{
    //using var scope = logger.BeginScope("Endpoint request time = {time} - {userId}",
    //    DateTime.Now, 19921);

    //using var scope = logger.BeginScope(new {userId = 8888, time = DateTime.Now, exField = "WOW" });
    logger.LogInformation("Info from program");
    service.Do();
    return DateTime.Now;
})
.WithOpenApi();
app.Run();

