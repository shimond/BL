using API.Mapping;

namespace API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGarageService, GarageService>();
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
        services.AddDbContext<GarageContext>(options => options.UseInMemoryDatabase("Cars"));
        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        return services;
    }

    public static IServiceCollection AddMappingServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(GarageProfile));
        return services;
    }


}
