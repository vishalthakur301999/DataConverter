using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConverter.Domain.Entities
{
    public partial class Flight
    {
        public Guid FLightId { get; set; }
        public string FlightNumber { get; set; }
        public string AirLine { get; set;  }
        public double Fare { get; set; }
        public string DeptTime { get; set; }
        public string ArrivalTime { get; set; }
        public Guid SourceCode { get; set; }
        public Guid DestinationCode { get; set; }
        public Guid DesignatedAircraftId { get; set; }
        public Guid DesignatedPilotId { get; set; }
        public Guid ProvidedAmenitiesId { get; set; }
        public Airport Source { get; set; }
        public Airport Destination { get; set; }
        public Aircraft DesignatedAircraft { get; set; }
        public Pilot DesignatedPilot { get; set; }
        public Amenities ProvidedAmenities { get; set; }
    }

    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(e => e.FLightId);
            builder.Property(e => e.FlightNumber).HasColumnType("varchar(8)").IsRequired();
            builder.Property(e => e.AirLine).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.DeptTime).HasColumnType("varchar(8)").IsRequired();
            builder.Property(e => e.ArrivalTime).HasColumnType("varchar(8)").IsRequired();
        }
    }
}