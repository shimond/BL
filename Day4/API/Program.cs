using API.Extensions;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwagger()
    .AddInfrastructureServices(builder.Configuration)
    .AddMappingServices()
    .AddApplicationServices();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.Run();
