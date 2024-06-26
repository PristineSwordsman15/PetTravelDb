﻿using Microsoft.AspNetCore.Identity;
using System.Net.Http.Headers;

namespace PetTravelDb.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public string PostalAddress { get; set; }

        public string Gender { get; set; }

       

    }
}