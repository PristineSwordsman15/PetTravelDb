using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetTravelDb.Models;

namespace PetTravelDb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PetTravelDb.Models.Pet> Pet { get; set; } = default!;
        public DbSet<PetTravelDb.Models.Owner> Owner { get; set; } = default!;
        public DbSet<PetTravelDb.Models.Flights> Flights { get; set; } = default!;
        public DbSet<PetTravelDb.Models.Airlines> Airlines { get; set; } = default!;
        public DbSet<PetTravelDb.Models.BookingProcess> BookingProcess { get; set; } = default!;
    }
}
