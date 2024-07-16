using System.ComponentModel.DataAnnotations;

namespace PetTravelDb.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        [Required, MaxLength(200)]
        public string PetName { get; set; }
        [MaxLength(200)]
        public string PetNotes { get; set; }
        [Required, MaxLength(50)]
        public string Species { get; set; }
        [Required, MaxLength(50)]
        public string Breed { get; set; }

        public int OwnerID { get; set; }

        public  Owner Owner  { get; set; }

        public  int PetAge { get; set; }
        public ICollection<PetFlight> PetFlight { get; set; }

    }
}
