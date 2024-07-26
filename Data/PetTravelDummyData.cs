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

                var airlines = new Airlines[]
                {
                     new Airlines
            {
             AirlinesName = "Mslaysia Airlines",
             AirlinesDescription= "MH",

      
                     }

    };
                ApplicationDbContext.Airlines.AddRange(airlines);
                ApplicationDbContext.SaveChanges();
        }
            }
        }
    }

