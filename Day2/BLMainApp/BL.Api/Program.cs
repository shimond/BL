using BL.Api.Contracts;
using BL.Api.DataContext;
using BL.Api.Routes;
using BL.Api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<MyDbContext>(x => x.UseInMemoryDatabase("BL"));
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapProductsRoutes();

app.Run();

//app.UseStaticFiles();
////if(app.UseDeveloperExceptionPage())

//app.UseCors();
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync(" M1 Start ");// first
//    await next();
//    await context.Response.WriteAsync(" M1 Finished ");
//});

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync(" M2 Start ");
//    await next();
//    await context.Response.WriteAsync(" M2 Finished ");
//});


//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("  Hello World!  ");
//});




//class TaskRunner
//{
//    void Run(Action action)
//    {
//        Task.Factory.StartNew(action)
//            .ContinueWith(x=> Console.WriteLine(x.Exception),  
//            TaskContinuationOptions.OnlyOnFaulted);
//    }
//}