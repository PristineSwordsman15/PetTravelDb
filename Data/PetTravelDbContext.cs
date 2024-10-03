using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetTravelDb.Models;

namespace PetTravelDb.Data
{
    public class PetTravelDbContext : DbContext
    {
        public PetTravelDbContext (DbContextOptions<PetTravelDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<PetTravelDb.Models.Airlines> Airlines { get; set; } = default;
        public DbSet<PetTravelDb.Models.Flights> Flights { get; set; } = default!;
        public DbSet<PetTravelDb.Models.Owner> Owner { get; set; } = default!;
        public DbSet<PetTravelDb.Models.Pet> Pet { get; set; } = default!;

        public DbSet<IdentityUser> IdentityUser { get; set; }
    }
}
