
namespace API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGarageService, GarageService>();
        return services;
    }

    public static IServiceCollection AddExceptionHandling(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddExceptionHandler<ItemResultExceptionHandler>();
        return services;
    }

    public static IServiceCollection AddHeathCheck(this IServiceCollection services)
    {

        services.AddHealthChecks()
              .AddDiskStorageHealthCheck(x =>
              {
                  x.AddDrive(@"C:\", minimumFreeMegabytes: 1100000);
                  x.CheckAllDrives = true;
              }, "Disk storage");



        services.AddHealthChecksUI(options =>
        {
            options.SetEvaluationTimeInSeconds(15);
            options.MaximumHistoryEntriesPerEndpoint(60);
            options.AddHealthCheckEndpoint("Garage Management API", "/health");
        }).AddInMemoryStorage();
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddDbContext<GarageContext>(options => options.UseSqlServer(configuration["ConnectionStrings:Cars"]));
        return services;
    }

    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        services.ConfigureOptions<ConfigureSwaggerOptions>();

        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.ResolveConflictingActions(apiDescriptions =>
            {
                return apiDescriptions.First();
            });
        });
        return services;
    }

    public static IServiceCollection AddMappingServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(GarageProfile));
        return services;
    }

}
