namespace PetTravelDb.Models
{
    public class Airlines
    {
        public int AirlinesID { get; set; }
        public string AirlinesName { get; set; }
        public string AirlinesDescription { get; set; }

        public ICollection<Flights> Flights { get; set; }




    }
}
