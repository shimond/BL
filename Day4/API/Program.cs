
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddVersioning()
    .AddSwagger()
    .AddExceptionHandling()
    .AddInfrastructureServices(builder.Configuration)
    .AddMappingServices()
    .AddHeathCheck()
    .AddApplicationServices();


var app = builder.Build();

app
    .MapApis()
    .MapSwagger()
    .UseHttpsRedirection();
app.Run();
