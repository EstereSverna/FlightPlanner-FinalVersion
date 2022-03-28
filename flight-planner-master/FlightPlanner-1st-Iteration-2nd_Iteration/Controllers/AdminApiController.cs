using AutoMapper;
using FlightPlanner.Core.DTO;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FlightPlanner.Controllers
{
    [Route("admin-api")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class AdminApiController : BaseController
    {
        public AdminApiController(IFlightService flightService, IEnumerable<IValidator> validators, IMapper mapper)
        {
            _flightService = flightService;
            _validators = validators;
            _mapper = mapper;
        }

        [HttpGet, Authorize]
        [Route("flights/{id}")]
        public IActionResult GetFlights(int id)
        {
            lock (_flightLock)
            {
                var flight = _flightService.GetFlightWithAirports(id);
                
                return flight == null? NotFound() : Ok(flight);
            }
        }

        [HttpPut, Authorize]
        [Route("flights")]
        public IActionResult PutFlight(AddFlightDto request)
        {
            lock (_flightLock)
            {
                if (!_validators.All(v => v.Validate(request)))
                    return BadRequest();
            
                if (_flightService.FlightExistsInDb(request))
                    return Conflict();

                var flight = _mapper.Map<Flight>(request);
                _flightService.Create(flight);

                return Created("",_mapper.Map<AddFlightDto>(flight));
            }
        }

        [HttpDelete, Authorize]
        [Route("flights/{id}")]
        public IActionResult DeleteFlights(int id)
        {
            lock (_flightLock)
            {
                _flightService.DeleteFlightById(id);
               
                return Ok();
            }
        }
    }
}
