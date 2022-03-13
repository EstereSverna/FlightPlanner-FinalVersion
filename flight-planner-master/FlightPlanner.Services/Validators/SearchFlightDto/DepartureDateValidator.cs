using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators.SearchFlightDto
{
    public class DepartureDateValidator : IValidatorSearchFlightDto
    {
        public bool Validate(Core.DTO.SearchFlightDto request)
        {
            return !string.IsNullOrEmpty(request?.DepartureDate);
        }
    }
}
