using AuthExample.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization(x =>
x.AddPolicy("shimonPolicy", x => x.RequireClaim("email").RequireRole("admin")));
builder.Services.AddAuthentication("Bearer").AddJwtBearer();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapPost("/endpoint", (Person p ) =>
{
    return DateTime.Now.ToString();
}).AddEndpointFilter(async (context, next) =>
{
    return await next(context);
});

app.MapGet("/wow", (int? valInt, string? niceString, double? theDouble) =>
{
    return Results.Ok(DateTime.Now);
}).AddEndpointFilter(async (context, next) =>
{
    return await next(context);
});
;// .RequireAuthorization("shimonPolicy");

app.MapGet("/auth", (IHttpContextAccessor httpContext) =>
{
    //httpContext.HttpContext.User.Claims
    return DateTime.Now;
}).RequireAuthorization();

app.Run();

