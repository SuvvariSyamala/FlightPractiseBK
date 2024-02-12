using FlightManagement.Entitys;

namespace FlightManagement.Services
{
    public interface IFlightInterface
    {
        void AddFlight(Flight flight);

        void UpdateFlight(Flight flight);


        void DeleteFlight(string flightNumber);


        Flight GetFlightById(string flightNumber);


        List<Flight> GetFlights();
    }
}
