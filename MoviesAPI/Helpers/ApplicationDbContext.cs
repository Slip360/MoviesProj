using Microsoft.EntityFrameworkCore;
using MoviesDataAccess.Entities;

namespace MoviesAPI.Helpers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Gender> Genders => Set<Gender>();
        public DbSet<Actor> Actors => Set<Actor>();
    }
}