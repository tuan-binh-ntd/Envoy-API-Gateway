using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeesController : ControllerBase
    {
        private static readonly string[] _coffees = new[]
        {
            "Flat White", "Long Black", "Latte", "Americano", "Cappuccino"
        };

        [HttpGet]
        public ActionResult Get()
        {
            var rng = new Random();
            return Ok(_coffees[rng.Next(_coffees.Length)]);
        }
    }
}
