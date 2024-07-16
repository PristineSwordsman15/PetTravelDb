using System.ComponentModel.DataAnnotations;

namespace PetTravelDb.Models
{
    public class PetFlight
    {
        [Key]
       public int PetFlightId { get; set; }
        
        public Pet Pet { get; set; }
        
        public int FlightId { get; set;}
        public Flights Flights { get; set; }
        public int PetID { get; set;}
        public BookingProcess BookingProcess { get; set; }           
    }
}
