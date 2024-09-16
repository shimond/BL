namespace BL.Api.Contracts;
public interface IProductRepository
{
    Task<List<Product>> GetProductsAsync();
    Task<Product?> GetProductById(int id);
}
