using AutoMapper;
using FlightPlanner.Core.DTO;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FlightPlanner.Controllers
{
    [Route("api")]
    [ApiController]
    [EnableCors]
    public class CustomerApiController : BaseController
    {
        public CustomerApiController (IFlightService flightService, IEnumerable<IValidatorSearchFlightDto> searchValidators, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
            _searchValidators = searchValidators;
        }

        [HttpGet]
        [Route("Airports")]
        public IActionResult SearchAirports(string search)
        {
            lock (_flightLock)
            {
                var airports = _flightService.SearchAirports(search);

                return Ok(airports);
            }
        }

        [HttpPost]
        [Route("flights/search")]
        public IActionResult SearchFlights(SearchFlightDto request)
        {
            lock (_flightLock)
            {
                if (!_searchValidators.All(v => v.Validate(request)))
                    return BadRequest();
                List<Flight> pageResultList = _flightService.FindFlights(request);
                return Ok(new PageResult(pageResultList));
            }
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult SearchFlight(int id)
        {
            lock (_flightLock)
            {
                var flight = _flightService.GetFlightWithAirports(id);

                return flight == null ? NotFound() : Ok(flight);
            }
        }
    }
}
