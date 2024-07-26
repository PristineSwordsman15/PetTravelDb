using System.ComponentModel.DataAnnotations;

namespace PetTravelDb.Models
{
    public class BookingProcess
    {
        [Key]
        public int BookingProcessID { get; set; }
        [MaxLength(6)]
        public string BookingRefNo { get; set; }
        [Required,MaxLength (6)]
        public string BookingProcessCard { get; set; }
        public string BookingProcesEmail { get; set; }
        public string BookingProcesPhone { get; set; }

        public DateTime BookingDate { get; set; }

        public int PetFlight { get; set; }
       
    }
}