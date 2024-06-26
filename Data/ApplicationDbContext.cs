using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetTravelDb.Models;

namespace PetTravelDb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
       public DbSet<PetFlight> PetFlights { get; set; }
    }
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
   {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(250);
            builder.Property(u => u.LastName).HasMaxLength(250);
            builder.Property(u => u.PhoneNumber).HasMaxLength(250);
            builder.Property(u => u.EmailAddress).HasMaxLength(250);
            builder.Property(u => u.Gender).HasMaxLength(50);
            builder.Property(u => u.PostalAddress).HasMaxLength(250);
        }
   }
      
    
    

    
}

