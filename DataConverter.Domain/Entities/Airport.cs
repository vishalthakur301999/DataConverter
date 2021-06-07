using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConverter.Domain.Entities
{
    public partial class Airport
    {
        public Guid AirportCode { get; set; }
        public string AirportName { get; set; }
        public string AirportCity { get; set; }
        public string AirportCountry { get; set; }
        public Boolean IsInternational { get; set; }
    }

    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(e => e.AirportCode);
            builder.Property(e => e.AirportName).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.AirportCity).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.AirportCountry).HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}