using FlightPlanner.Core.DTO;
using FlightPlanner.Core.Services;
using System;

namespace FlightPlanner.Services.Validators
{
    public class AirportNameEqualityValidator : IValidator
    {
        public bool Validate(AddFlightDto request)
        {
            return !string.Equals(request.From.Airport.Trim(), request.To.Airport.Trim(), 
                StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
