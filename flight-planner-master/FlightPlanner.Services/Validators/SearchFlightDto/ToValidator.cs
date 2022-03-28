using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators.SearchFlightDto
{
    public class ToValidator : IValidatorSearchFlightDto
    {
        public bool Validate(Core.DTO.SearchFlightDto request)
        {
            return !string.IsNullOrEmpty(request?.To);
        }
    }
}
