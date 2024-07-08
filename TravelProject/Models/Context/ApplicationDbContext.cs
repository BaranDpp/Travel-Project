using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TravelProject.Models.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<TouristSpot> TouristSpots { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
    }
}