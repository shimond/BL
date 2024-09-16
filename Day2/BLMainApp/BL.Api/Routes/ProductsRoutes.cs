using BL.Api.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BL.Api.Routes;
public static class ProductsRoutes
{
    public static IEndpointRouteBuilder MapProductsRoutes(this IEndpointRouteBuilder app)
    {
        var productsGroup = app.MapGroup("api/products")
                .WithTags("Products");

        productsGroup.MapGet("", GetAllProducts);
        productsGroup.MapGet("{id}", GetById);

        return app;
    }

    static async Task<Results<NotFound, Ok<Product>>> GetById(int id, string? fieldOrder, IProductRepository repository)
    {
        var result = await repository.GetProductById(id);
        if (result == null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(result);
    }

    static async Task<Ok<List<Product>>> GetAllProducts(IProductRepository repository)
    {
        var result = await repository.GetProductsAsync();
        return TypedResults.Ok(result);
    }


}
