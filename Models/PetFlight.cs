namespace PetTravelDb.Models
{
    public class PetFlight
    {
       public int PetFlightId { get; set; }
        public Pet Pet { get; set; }
        public int FlightId { get; set;}
        public Flights Flights { get; set; }
        public string PetID { get; set;}
        public BookingProcess BookingProcess { get; set; }           
    }
}
