using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManagement.Entitys
{
    public class Flight
    {
        [Key]
        public string FlightNumber { get; set; }

        public string AirlineName { get; set; }

        public string DepatureCity { get; set; }

        public DateTime DepatureTime { get; set; }

        public string ArrivalCity { get; set; }

        public DateTime ArrivalTime { get; set; }

        public float price { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public User PostedUser { get; set; }


    }
}
