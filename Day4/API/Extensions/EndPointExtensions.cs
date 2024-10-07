using Asp.Versioning.Builder;
using Asp.Versioning.Conventions;

namespace API.Extensions;

public static class EndPointExtensions
{
    private static ApiVersionSet GetVersionSet(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = app.NewApiVersionSet()
                      .HasApiVersion(1.0)
                      .HasApiVersion(2.0)
                      .HasApiVersion(3.0)
                      .ReportApiVersions()
                      .Build();
        return apiVersionSet;
    }

    public static WebApplication MapApis(this WebApplication app)
    {
        var apiVersionSet = app.GetVersionSet();
        app.MapGroup("v{version:apiVersion}")
            .WithApiVersionSet(apiVersionSet)
            .MapCarsApis();
        return app;
    }

    public static WebApplication MapSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            foreach (var description in app.DescribeApiVersions())
            {
                c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Garage Management API {description.ApiVersion}");
            }
        });

        return app;

    }
}