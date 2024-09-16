using BL.Api.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace BL.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository, IServiceProvider serviceProvider)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType<List<Product>>(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("GetTime")]
        [OutputCache(Duration =100000)]
        public DateTime Get()
        {
            return DateTime.Now;
        }
    }
}
