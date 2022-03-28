using FlightPlanner.Core.DTO;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators
{
    public class ToAirportValidator : IValidator
    {
        public bool Validate(AddFlightDto request)
        {
            return request?.To != null;
        }
    }
}
