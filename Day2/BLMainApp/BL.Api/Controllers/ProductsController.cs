using BL.Api.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Options;

namespace BL.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly RedisConfig redisConfig;
        private readonly IProductRepository productRepository;

        public ProductsController(
            IProductRepository  productRepository,
            IOptions<RedisConfig> redisConfigOptions,
            IServiceProvider serviceProvider)
        {
            redisConfig = redisConfigOptions.Value;
            this.productRepository = productRepository;
            serviceProvider.GetKeyedService<IProductRepository>("Mock");
        }

        [HttpGet("redis")]
        public ActionResult<RedisConfig> GetConfig()
        {
            return Ok(redisConfig);
        }

        [HttpGet]
        [ProducesResponseType<List<Product>>(200)]
        [ProducesResponseType(400)]
        //[Authorize(policy:"Manager")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await productRepository.GetProductsAsync();
            return Ok("asD");
        }

        [HttpGet("GetTime")]
        [OutputCache(Duration = 100000)]
        public DateTime Get()
        {
            return DateTime.Now;
        }
    }
}
