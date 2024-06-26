namespace PetTravelDb.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string PetNotes { get; set; }
        
        public string Species { get; set; }

        public string Breed { get; set; }

        public int OwnerID { get; set; }

        public  Owner Owner  { get; set; }

        public  int PetAge { get; set; }
        public ICollection<PetFlight> PetFlight { get; set; }

    }
}
