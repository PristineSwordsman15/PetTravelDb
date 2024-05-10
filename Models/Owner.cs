namespace PetTravelDb.Models
{
    public class Owner
    {
        public int OwnerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FlightID { get; set; }
        public int PhoneNumber { get; set;}
        public int BookingRefNo { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }    
    }
}
