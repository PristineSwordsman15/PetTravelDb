using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace PetTravelDb.Data
{
    //Add profile data for application userd by adding properties to the AppUser class
    public class ApplicationUser : IdentityUser
    {
       
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter you first name"),MaxLength(20,ErrorMessage ="Please enter a first name that is upto 20 characters"),Display(Name= "First Name")]//required for user imput
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public string PostalAddress { get; set; }

        public string Gender { get; set; }

       

    }
}
