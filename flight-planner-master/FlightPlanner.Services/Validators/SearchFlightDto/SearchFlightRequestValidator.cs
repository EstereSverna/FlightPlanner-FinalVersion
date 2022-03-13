using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators.SearchFlightDto
{
    public class SearchFlightRequestValidator : IValidatorSearchFlightDto
    {
        public bool Validate(Core.DTO.SearchFlightDto request)
        {
            return request != null;
        }
    }
}
