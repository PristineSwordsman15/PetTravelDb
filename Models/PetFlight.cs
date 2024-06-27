using System.ComponentModel.DataAnnotations;

namespace PetTravelDb.Models
{
    public class PetFlight
    {
        [Key]
       public int PetFlightId { get; set; }
        [Required,MaxLength(250)] 
        public Pet Pet { get; set; }
        [Required, MaxLength(10)]
        public int FlightId { get; set;}
        public Flights Flights { get; set; }
        public string PetID { get; set;}
        public BookingProcess BookingProcess { get; set; }           
    }
}
