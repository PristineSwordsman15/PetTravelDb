using Microsoft.EntityFrameworkCore;
using PetTravelDb.Models;
using System.Diagnostics;
// Data/DBInitializer.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetTravelDb.Models;
using System;
using System.Linq;
namespace PetTravelDb.Data.DBInitialier
{
    public class DBInitializer
    {
     // Data/DBInitializer.cs
     }




namespace PetTravel.Data
    {
        public static class DBInitializer
        {
            
            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new ApplicationDbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
                {
                    // Look for any pets.
                    if (context.Pets.Any())
                    {
                        return;   // DB has been seeded
                    }

                    var pets = new Pet[]
                    {
                    new Pet{PetName="Buddy", Species="Dog", PetAge=3},
                    new Pet{PetName="Mittens", Species="Cat", PetAge=5},
                    new Pet{PetName="Goldie", Species="Fish", PetAge=1}
                    };

                    foreach (Pet p in pets)
                    {
                        context.Pets.Add(p);
                    }
                    context.SaveChanges();
                    var travels = new Travel[]
                    {
                        new Travel{PetId=1, Destination="New York", TravelDate=DateTime.Parse("2023-05-01")},
                        new Travel{PetId=2, Destination="San Francisco", TravelDate=DateTime.Parse("2023-06-15")},
                    new Travel{PetId=3, Destination="Chicago", TravelDate=DateTime.Parse("2023-07-20")}
                    };

                    foreach (Travel t in travels)
                    {
                        context.Travel.Add(t);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}

