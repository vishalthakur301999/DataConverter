using System.Threading.Tasks;
using DataConverter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataConverter.Persistence
{
    public class ConverterContext: DbContext, IConverterContext
    {
        public ConverterContext(DbContextOptions<ConverterContext> options) : base(options)
        {
        }
        
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Amenities> Amenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new AircraftConfiguration());
            modelBuilder.ApplyConfiguration(new AirportConfiguration());
            modelBuilder.ApplyConfiguration(new PilotConfiguration());
            modelBuilder.ApplyConfiguration(new AmenitiesConfiguration());
        }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
    }
}