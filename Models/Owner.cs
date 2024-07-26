using System.ComponentModel.DataAnnotations;

namespace PetTravelDb.Models
{
    public class Owner
    {
        [Key]
        public int OwnerID { get; set; }
        [Required,MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }
        public int FlightID { get; set; }
        [Required, MaxLength(11)]
        public int PhoneNumber { get; set;}
        [Required, MaxLength(6)]
        public int BookingRefNo { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
