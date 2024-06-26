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
            
            public static void Initialize(IServiceProvider serviceProvider)
            {
                context.Database.EnsureCreated();

                // Look for any existing data.
                if (context.Pets.Any())
                {
                    return;   // DB has been seeded
                }

                var owners = new Owner[]
                {
            new Owner { Name = "John Doe", ContactInformation = "john.doe@example.com" },
            new Owner { Name = "Jane Smith", ContactInformation = "jane.smith@example.com" }
                };

                foreach (var o in owners)
                {
                    context.Owners.Add(o);
                }
                context.SaveChanges();

                var Pets = new Pet[]
                {
            new TravelPet { Name = "Buddy", Species = "Dog", Breed = "Golden Retriever", Age = 3, OwnerId = owners[0].OwnerId },
            new TravelPet { Name = "Mittens", Species = "Cat", Breed = "Siamese", Age = 2, OwnerId = owners[1].OwnerId }
                };

                foreach (var tp in travelPets)
                {
                    context.TravelPets.Add(tp);
                }
                context.SaveChanges();

                var airlines = new Airline[]
                {
            new Airline { Name = "Airways A" },
            new Airline { Name = "Airways B" }
                };

                foreach (var a in airlines)
                {
                    context.Airlines.Add(a);
                }
                context.SaveChanges();

                var flights = new Flight[]
                {
            new Flight { FlightNumber = "AA123", DepartureTime = DateTime.Now.AddHours(2), ArrivalTime = DateTime.Now.AddHours(5), AirlineId = airlines[0].AirlineId },
            new Flight { FlightNumber = "BB456", DepartureTime = DateTime.Now.AddHours(3), ArrivalTime = DateTime.Now.AddHours(6), AirlineId = airlines[1].AirlineId }
                };

                foreach (var f in flights)
                {
                    context.Flights.Add(f);
                }
                context.SaveChanges();

                var petFlights = new PetFlight[]
                {
            new PetFlight { PetId = Pets[0].PetId, FlightId = flights[0].FlightId },
            new PetFlight { PetId = Pets[1].PetId, FlightId = flights[1].FlightId }
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
                    context.BookingProcesses.Add(bp);
                }
                context.SaveChanges();
            }
        }

