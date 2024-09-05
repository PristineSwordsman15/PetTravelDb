using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace PetTravelDb.Models
{
    public class Flights
    {
        [Key]
        
        public int FlightsId { get; set; }
        [Required, MaxLength(10)]
        public string FlightNumber { get; set; }
        [Required, MaxLength(6)]
        public string BookingRefNo { get; set; }
        
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string Origin { get; set; }
        [Required, MaxLength(250)]
        public string Destination { get; set; }
        [Required, MaxLength(250)]
        public int PetID { get; set; }
        [Required, MaxLength(10)]
        public string PetName { get; set; }

        public string Status { get; set; }

        public int AirlinesId { get; set; }

        public Airlines Airline { get; set; }


    }
}


