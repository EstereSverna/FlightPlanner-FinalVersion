using FlightPlanner.Core.DTO;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators
{
    public class ToAirportNameValidator : IValidator
    {
        public bool Validate(AddFlightDto request)
        {
            return !string.IsNullOrEmpty(request?.To?.Airport);
        }
    }
}
