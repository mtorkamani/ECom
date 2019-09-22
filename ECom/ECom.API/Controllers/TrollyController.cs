using ECom.API.Contracts;
using ECom.Common;
using ECom.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace ECom.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class TrolleyController : ControllerBase
    {
        private readonly ITrolleyService trolleyService;
        private readonly ILogger<TrolleyController> logger;

        public TrolleyController(ITrolleyService trolleyService, ILogger<TrolleyController> logger)
        {
            this.trolleyService = trolleyService;
            this.logger = logger;
        }

        [HttpPost("trolleyTotal")]
        public IActionResult Total([FromBody]TrolleyModel trolleyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trolleyModelJson = JsonConvert.SerializeObject(trolleyModel);
            System.Diagnostics.Trace.WriteLine(trolleyModelJson);
            logger.LogError(trolleyModelJson);

            try
            {
                var trolley = CreateTrolley(trolleyModel);
                var total = trolleyService.CalculateTotal(trolley);
                return Ok(total);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Operation failed.");
            }
        }

        private Trolley CreateTrolley(TrolleyModel trolleyModel)
        {
            var trolley = new Trolley();
            var products = trolleyModel.Products.ToDictionary(p => p.Name, p => new ProductRef
            {
                Name = p.Name,
                Price = p.Price,
            });
            foreach (var item in trolleyModel.Quantities)
            {
                trolley.AddItem(products[item.Name], item.Quantity);
            }
            foreach (var item in trolleyModel.Specials.SelectMany(s => s.Quantities))
            {
                var special = new TrolleySpecial();
                special.AddItem(products[item.Name], item.Quantity);
                trolley.AddSpecial(special);
            }
            return trolley;
        }
    }
}