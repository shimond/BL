using BL.Api.Contracts;
using BL.Api.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BL.Api.Services;

public class ProductRepository(MyDbContext dbContext) : IProductRepository
{
    public async Task<List<Product>> GetProductsAsync()
    {
        var products = await dbContext.Products.AsNoTracking().ToListAsync();
        return products;
    }
    public async Task<Product?> GetProductById(int id)
    {
        var product = await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return product;
    }

    public async Task<Product> AddNewProduct(Product p)
    {
        //dbContext.ChangeTracker;
        await dbContext.Products.AddAsync(p);
        await dbContext.SaveChangesAsync();
        return p;
    }
}
