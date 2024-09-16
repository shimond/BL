using BL.Api.Contracts;
using BL.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOutputCache();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddCors(x=> x.AddDefaultPolicy(o=> o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();
app.UseOutputCache();
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("test", (IConfiguration configuration) => configuration["blValue:value"]);

app.MapControllers();

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




class TaskRunner
{
    void Run(Action action)
    {
        Task.Factory.StartNew(action)
            .ContinueWith(x=> Console.WriteLine(x.Exception),  
            TaskContinuationOptions.OnlyOnFaulted);
    }
}