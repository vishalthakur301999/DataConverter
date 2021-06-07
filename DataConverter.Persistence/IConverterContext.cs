using DataConverter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataConverter.Persistence
{
    public interface IConverterContext
    {
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        Task<int> SaveChangesAsync();
    }
}