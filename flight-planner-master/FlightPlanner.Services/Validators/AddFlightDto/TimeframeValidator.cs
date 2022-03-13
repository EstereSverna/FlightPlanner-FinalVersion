using FlightPlanner.Core.DTO;
using FlightPlanner.Core.Services;
using System;

namespace FlightPlanner.Services.Validators
{
    public class TimeFrameValidator : IValidator
    {
        public bool Validate(AddFlightDto request)
        {
            var arrivalTime = DateTime.Parse(request.ArrivalTime);
            var departureTime = DateTime.Parse(request.DepartureTime);
            return arrivalTime > departureTime;
        }
    }
}
