using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using RequirementsFromConfig.Requirements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
        .AddNegotiate();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("FileBasedPolicy", policy =>
        policy.Requirements.Add(new FileBasedAuthenticationRequirement()));
});

builder.Services.AddSingleton<IAuthorizationHandler, FileBasedAuthenticationHandler>();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapGet("", () => "Hello World!").RequireAuthorization("FileBasedPolicy");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
