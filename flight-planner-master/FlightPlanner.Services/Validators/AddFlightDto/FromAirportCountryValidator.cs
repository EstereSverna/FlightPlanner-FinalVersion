using FlightPlanner.Core.DTO;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators
{
    public class FromAirportCountryValidator : IValidator
    {
        public bool Validate(AddFlightDto request)
        {
            return !string.IsNullOrEmpty(request?.From?.Country);
        }
    }
}
