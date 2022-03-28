using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.DTO;
using System.Collections.Generic;

namespace FlightPlanner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public Flight GetFlightWithAirports(int id)
        {
            return Query<Flight>()
                .Include(f => f.From)
                .Include(f => f.To)
                .SingleOrDefault(f => f.Id == id);
        }

        public List<Airport> SearchAirports(string search)
        {
                search = search.ToLower().Trim();
            var fromAirport = Get<Airport>().Where(a =>
            a.AirportName.ToLower().Trim().Contains(search)
            || a.Country.ToLower().Trim().Contains(search)
            || a.City.ToLower().Trim().Contains(search))
            .Select(a => a);

            return fromAirport.ToList(); 
        }

        public void DeleteFlightById(int id)
        {
            var flight = GetFlightWithAirports(id);

            if (flight != null)
                Delete(flight);
        }

         public bool FlightExistsInDb(AddFlightDto request)
        {
            return Query().Any(f =>  f.DepartureTime == request.DepartureTime
                  && f.ArrivalTime == request.ArrivalTime
                  && f.From.AirportName.Trim().ToLower() == request.From.Airport.Trim().ToLower()
                  && f.To.AirportName.Trim().ToLower() == request.To.Airport.Trim().ToLower());
        }

        public List<Flight> FindFlights(SearchFlightDto request)
        { 
           return Query().Where(a =>
                       a.From.AirportName == request.From
                       && a.To.AirportName == request.To
                       && a.DepartureTime.Substring(0, 10) == request.DepartureDate)
                        .IgnoreAutoIncludes()
                       .Select(a => a).ToList();          
        }
    }
}
