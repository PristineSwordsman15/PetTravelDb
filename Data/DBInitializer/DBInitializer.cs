using Microsoft.EntityFrameworkCore;
using PetTravelDb.Models;
using System.Diagnostics;
// Data/DBInitializer.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetTravelDb.Models;
using System;
using System.Linq;
using PetTravelDb.Data.Migrations;
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

            public static void Initialize(ApplicationDbContext context)
            {
                context.Database.EnsureCreated();

                // Look for any existing data.
                if (context.Pet.Any())
                {
                    return;   // DB has been seeded
                }

                var owners = new Owner[]
                {
            new Owner { FirstLastName= "John Doe", EmailAddress = "john.doe@example.com" },
            new Owner { FirstLastName = "Jane Smith", EmailAddress = "jane.smith@example.com" }
                };

                foreach (var o in owners)
                {
                    context.Owner.Add(o);
                }
                context.SaveChanges();

                var Pets = new Pet[]
                {
            new Pet { PetName = "Buddy", Species = "Dog", Breed = "Golden Retriever", PetAge = 3, OwnerID = owners[0].OwnerID },
            new Pet { PetName = "Mittens", Species = "Cat", Breed = "Siamese", PetAge = 2, OwnerID = owners[1].OwnerID }
                };

                foreach (var p in Pets)
                {
                    context.Pet.Add(tp);
                }
                context.SaveChanges();

                var airlines = new Airlines[]
                {
            new Airlines { Name = "Airways A" },
            new Airlines { Name = "Airways B" }
                };

                foreach (var a in airlines)
                {
                    context.Airlines.Add(a);
                }
                context.SaveChanges();

                var flights = new Flights[]
                {
            new Flights { FlightNumber = "AA123", DepartureTime = DateTime.Now.AddHours(2), ArrivalTime = DateTime.Now.AddHours(5), FlightsId = airlines[0].AirlineId },
            new Flights { FlightNumber = "BB456", DepartureTime = DateTime.Now.AddHours(3), ArrivalTime = DateTime.Now.AddHours(6), FlightsId = airlines[1].AirlineId }
                };

                foreach (var f in flights)
                {
                    context.Flights.Add(f);
                }
                context.SaveChanges();

                var petFlights = new PetFlight[]
                {
            new PetFlight { PetFlightId = Pets[0].PetId, FlightId = flights[0].FlightId },
            new PetFlight { PetFlightId = Pets[1].PetId, FlightId = flights[1].FlightId }
                };

                foreach (var pf in petFlights)
                {
                    context.PetFlights.Add(pf);
                }
                context.SaveChanges();

                var bookingProcesses = new BookingProcess[]
                {
            new BookingProcess { BookingDate = DateTime.Now, PetFlightId = petFlights[0].PetFlightId },
            new BookingProcess { BookingDate = DateTime.Now, PetFlightId = petFlights[1].PetFlightId }
                };

                foreach (var bp in bookingProcesses)
                {
                    context.BookingProcess.Add(bp);
                }
                context.SaveChanges();
            }
        }
    }
}


