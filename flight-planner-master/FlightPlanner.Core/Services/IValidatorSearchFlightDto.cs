using FlightPlanner.Core.DTO;

namespace FlightPlanner.Core.Services
{
    public interface IValidatorSearchFlightDto
    {
        bool Validate(SearchFlightDto request);
    }
}
