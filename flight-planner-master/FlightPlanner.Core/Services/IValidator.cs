using FlightPlanner.Core.DTO;

namespace FlightPlanner.Core.Services
{
    public interface IValidator
    {
        bool Validate(AddFlightDto request);
    }
}
