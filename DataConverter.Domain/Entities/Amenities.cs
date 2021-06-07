using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConverter.Domain.Entities
{
    public partial class Amenities
    {
        public Guid AmenitiesId { get; set; }
        public Boolean MealsProvided { get; set; }
        public Boolean InFlightEntertainment { get; set; }
        public int BaggageLimit { get; set; }
        public double CancellationCharges { get; set; }
        public double FlightChangeCharges { get; set; }
    }

    public class AmenitiesConfiguration : IEntityTypeConfiguration<Amenities>
    {
        public void Configure(EntityTypeBuilder<Amenities> builder)
        {
            builder.HasKey(e => e.AmenitiesId);
        }
    }
}