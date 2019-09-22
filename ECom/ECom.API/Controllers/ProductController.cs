using ECom.Common;
using ECom.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECom.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Sort(SortOption sortOption)
        {
            try
            {
                var products = await productService.GetProductsAsync(sortOption);
                return Ok(products);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception); //TODO: Add logger
                return StatusCode(StatusCodes.Status500InternalServerError, "Operation failed.");
            }
        }
    }
}