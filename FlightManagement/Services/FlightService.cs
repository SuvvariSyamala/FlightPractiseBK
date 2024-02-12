using FlightManagement.Database;
using FlightManagement.Entitys;

namespace FlightManagement.Services
{
    public class FlightService : IFlightInterface
    {
        private readonly FlightContext Context = null;
        public FlightService(FlightContext context)
        {

            this.Context = context;

        }
        public void AddFlight(Flight flight)
        {


            var user = Context.Users.Find( flight.UserId);


            Context.Flights.Add(flight);
            Context.SaveChanges();

        }

        public void DeleteFlight(string  flightNumber)
        {
            var flightToDelete = Context.Flights.SingleOrDefault(c => c.FlightNumber == flightNumber);
            if (flightToDelete != null)
            {
                Context.Flights.Remove(flightToDelete);
                Context.SaveChanges();

            }
        }

        public Flight GetFlightById(string flightnumber)
        {
            return Context.Flights.Find(flightnumber);
        }

        public List<Flight> GetFlights()
        {
            var res = Context.Flights.ToList();
            return res;
        }

        public void UpdateFlight(Flight flight)
        {
            if (flight != null)
            {
                Context.Flights.Update(flight);
                Context.SaveChanges();

            }
        }
    }


}
