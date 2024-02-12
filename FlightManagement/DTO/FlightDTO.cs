using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManagement.DTO
{
    public class FlightDTO
    {
        public string FlightNumber { get; set; }

        public string AirlineName { get; set; }

        public string DepatureCity { get; set; }

        public DateTime DepatureTime { get; set; }

        public string ArrivalCity { get; set; }

        public DateTime ArrivalTime { get; set; }

        public float price { get; set; }

       
        public int UserId { get; set; }
        public int NameofUser {  get; set; }

    }
}
