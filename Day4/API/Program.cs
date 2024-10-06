
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

app.MapCarsApis();
app.Run();
