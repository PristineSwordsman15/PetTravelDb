using System.ComponentModel.DataAnnotations;

namespace PetTravelDb.Models
{
    public class Airlines
    {

        [Key]
        public int AirlinesId { get; set; }
        [Required, MaxLength(50)] 
        public string AirlinesName { get; set; }
        [Required, MaxLength(100)]
        public string AirlinesDescription { get; set; }
        [Required, MaxLength(50)]
        public ICollection<Flights> Flights { get; set; }




    }
}
