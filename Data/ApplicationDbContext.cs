using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetTravelDb.Models;

namespace PetTravelDb.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PetTravelDb.Models.Pet> Pet { get; set; } = default!;
        public DbSet<PetTravelDb.Models.Owner> Owner { get; set; } = default!;
        public DbSet<PetTravelDb.Models.Flights> Flights { get; set; } = default!;
        public DbSet<PetTravelDb.Models.Airlines> Airlines { get; set; } = default!;
        
       public DbSet<PetFlight> PetFlight { get; set; }
    }
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<IdentityUser>
   {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {

        }
   }
      
    
    

    
}

