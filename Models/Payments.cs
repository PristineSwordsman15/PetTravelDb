namespace PetTravelDb.Models
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public string OwnerId { get; set; } 
        public string OwnerName { get; set; } = string.Empty;
        public string OwnerEmail { get; set; } 
        public string OwnerPhone { get; set; } = string.Empty;
        

    }
}

    
    
