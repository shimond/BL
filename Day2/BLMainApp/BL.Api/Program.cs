using BL.Api.Contracts;
using BL.Api.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


var productsGroup = app.MapGroup("api/products")
    .WithTags("Products");

productsGroup.MapGet("", async (IProductRepository repository) =>
{
    var result = await repository.GetProductsAsync();
    return result;
});


productsGroup.MapGet("{id}", async Task<IResult>(int id, string? fieldOrder, IProductRepository repository) =>
{
    var result = await repository.GetProductById(id);
    if(result == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(result);
});

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