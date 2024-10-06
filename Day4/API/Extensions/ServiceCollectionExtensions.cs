using API.Mapping;

namespace API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGarageService, GarageService>();
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
