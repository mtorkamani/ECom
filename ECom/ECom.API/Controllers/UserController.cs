using ECom.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ECom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EComConfiguration configuration;

        public UserController(IOptions<EComConfiguration> configuration)
        {
            this.configuration = configuration.Value;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var user = new User
            {
                Name = "Mehdi Torkamani",
                Token = configuration.Token,
            };
            return Ok(user);
        }
    }
}