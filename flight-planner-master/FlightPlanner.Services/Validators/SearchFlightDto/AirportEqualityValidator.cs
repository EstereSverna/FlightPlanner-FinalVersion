using FlightPlanner.Core.Services;
using System;

namespace FlightPlanner.Services.Validators.SearchFlightDto
{
    public class AirportEqualityValidator : IValidatorSearchFlightDto
    {
        public bool Validate(Core.DTO.SearchFlightDto request)
        {
            return !string.Equals(request.From, request.To,
                StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
