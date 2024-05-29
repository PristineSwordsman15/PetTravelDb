using System.Drawing;

namespace PetTravelDb.Models
{
    public class Flights
    {
        public int FlightsId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int AnimalID { get; set; }
        public string AnimalName { get; set; }
        public int BookingRefNo { get; set; }
        public string Status { get; set; }                                                                                                         

    }
}
