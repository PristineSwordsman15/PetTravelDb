namespace PetTravelDb.Models
{
    public class BookingProcess
    {
        public int BookingProcessID { get; set; }
        public string BookingRefNo { get; set; }
        public string BookingProcessCard { get; set; }

        public string BookingProcesEmail { get; set; }
        public string BookingProcesPhone { get; set; }

        public DateTime BookingDate { get; set; }

        public int PetFlight { get; set; }
       
    }
}