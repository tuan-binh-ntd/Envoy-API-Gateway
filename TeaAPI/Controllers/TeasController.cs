using Microsoft.AspNetCore.Mvc;

namespace TeaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeasController : ControllerBase
    {
        private static readonly string[] _teas = new[]
        {
            "Green", "Peppermint", "Earl Grey", "English Breakfast", "Camomile"
        };

        [HttpGet]
        public ActionResult Get()
        {
            var rng = new Random();
            return Ok(_teas[rng.Next(_teas.Length)]);
        }
    }
}