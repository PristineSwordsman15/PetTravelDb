namespace PetTravelDb.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string PetNotes { get; set; }
        
        public string Species { get; set; }

        public int OwnerID { get; set; }

        public  int PetAge { get; set; }

    }
}
