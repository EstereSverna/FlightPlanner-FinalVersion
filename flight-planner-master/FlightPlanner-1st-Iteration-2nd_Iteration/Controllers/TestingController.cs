using FlightPlanner.Core.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("testing-api")]
    [ApiController]
    [EnableCors]
    public class TestingController : Controller
    {
        protected static object _flightLock = new object();
        private readonly IDbExtendedService _service;
        public TestingController(IDbExtendedService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route ("clear")]
        public IActionResult Clear()
        {
            lock (_flightLock)
            {
                _service.DeleteAll();
                return Ok();
            }
        }
    }
}
