using System.ComponentModel.DataAnnotations;

namespace PetTravelDb.Models
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        [Required,MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }
        public int FlightId { get; set; }
        [Required, MaxLength(11)]
        public int PhoneNumber { get; set;}
        [Required, Range(000001,999999,ErrorMessage = "The booking reference number has to be 6 digits, e.g. 000001 to 999999")]
        public int BookingRefNo { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required, Range(0,130, ErrorMessage ="The age can only be positive numbers upto 130")]
        public int Age { get; set; }
        public ICollection<Pet> Pets { get; set; }

       
    }
}
