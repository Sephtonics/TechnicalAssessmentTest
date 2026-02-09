using CoffeeAPI.Models;
using CoffeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrewedCoffeeController : ControllerBase
    {
        private readonly IBrewedCoffeeService _brewedCoffeeService;
        private static int _counter = 0;
        public BrewedCoffeeController(IBrewedCoffeeService brewedCoffeeService)
        {
            _brewedCoffeeService = brewedCoffeeService;
        }

        //Get Brew Coffee
        [HttpGet("")]
        public IActionResult Get()
        {
            var info = _brewedCoffeeService.GetInfo();

            if (info.Prepared.Month == 05 && info.Prepared.Day == 01)
                return new JsonResult(418);

            var counter = Interlocked.Increment(ref _counter);

            if (counter == 5)
            {
                return new JsonResult(HttpStatusCode.ServiceUnavailable);
            }

            return Ok(info);
        }
    }
}
