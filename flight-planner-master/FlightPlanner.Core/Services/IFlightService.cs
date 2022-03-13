using FlightPlanner.Core.DTO;
using FlightPlanner.Core.Models;
using System.Collections.Generic;

namespace FlightPlanner.Core.Services
{
    public interface IFlightService: IEntityService<Flight> 
    {
        Flight GetFlightWithAirports(int id);
        void DeleteFlightById(int id);
        bool FlightExistsInDb(AddFlightDto request);
        List<Flight> FindFlights(SearchFlightDto request);
        List<Airport> SearchAirports(string search);
    }
}
