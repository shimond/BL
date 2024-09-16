using BL.Api.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IProductRepository repository, ILogger<UsersController> logger) : ControllerBase
    {
        public void Test()
        {
            Console.WriteLine(repository);
        }
        //public UsersController(): this(null, null)
        //{

        //}
        //private readonly IProductRepository repository;
        //private readonly ILogger<UsersController> logger;

        //public UsersController(IProductRepository repository, ILogger<UsersController> logger)
        //{
        //    this.repository = repository;
        //    this.logger = logger;
        //}
    }
}
