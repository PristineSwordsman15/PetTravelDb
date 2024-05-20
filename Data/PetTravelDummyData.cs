using PetTravelDb.Controllers;
using PetTravelDb.Models;
using System.Diagnostics.SymbolStore;

namespace PetTravelDb.Data
{
    public class PetTravelDummyData
    {
        public static void AddData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var ApplicationDbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var pets = new Pet[]
                {
                     new Pet
            {
             PetName = "Michael",
             PetNotes = "Broken Leg",

             Breed = "Labrador",

             OwnerID = 26,

             PetAge = 8
                     }

    };
                ApplicationDbContext.Pet.AddRange(pets);
                ApplicationDbContext.SaveChanges();
        }
            }
        }
    }

