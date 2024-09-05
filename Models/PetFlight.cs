using System.ComponentModel.DataAnnotations;

namespace PetTravelDb.Models
{
    public class PetFlight
    {
        [Key]
       public int PetFlightId { get; set; }
        
        public Pet Pet { get; set; }
        [Required]
        public int FlightId { get; set;}
        public Flights Flights { get; set; }
        [Required]
        public int PetID { get; set;}
                  
    }
}
