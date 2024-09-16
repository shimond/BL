using BL.Api.Contracts;

namespace BL.Api.Services;

public class ProductRepository : IProductRepository
{
    public Task<List<Product>> GetProductsAsync()
    {
        List<Product> products = new List<Product>
        {
            new Product(1, "Product 1", "Description 1"),
            new Product(2, "Product 2", "Description 2"),
            new Product(3, "Product 3", "Description 3"),
            new Product(4, "Product 4", "Description 4"),
            new Product(5, "Product 5", "Description 5"),
            new Product(6, "Product 6", "Description 6"),
            new Product(7, "Product 7", "Description 7"),
            new Product(8, "Product 8", "Description 8"),
            new Product(9, "Product 9", "Description 9"),
            new Product(10, "Product 10", "Description 10"),
        };
        return Task.FromResult(products);
    }
}
