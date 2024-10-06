
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwagger()
    .AddInfrastructureServices(builder.Configuration)
    .AddMappingServices()
    .AddHeathCheck()
    .AddApplicationServices();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapCarsApis();
app.Run();
