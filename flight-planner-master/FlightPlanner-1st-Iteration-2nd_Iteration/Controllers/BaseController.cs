using AutoMapper;
using FlightPlanner.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlightPlanner.Controllers
{
     public abstract class BaseController : ControllerBase
    {
        protected IFlightService _flightService;
        protected static object _flightLock = new object();
        protected IEnumerable<IValidator> _validators;
        protected IEnumerable<IValidatorSearchFlightDto> _searchValidators;
        protected IMapper _mapper;

    }
}
