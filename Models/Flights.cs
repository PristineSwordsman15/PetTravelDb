using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace PetTravelDb.Models
{
    public class Flights
    {
        public int FlightsId { get; set; }
        public string FlightNumber { get; set; }
        public string BookingRefNo { get; set; }
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string Origin { get; set; }
        public string Destination { get; set; }
        public int AnimalID { get; set; }
        public string AnimalName { get; set; }
    }
}