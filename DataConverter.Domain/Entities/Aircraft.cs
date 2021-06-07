using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConverter.Domain.Entities
{
    public partial class Aircraft
    {
        [Key]
        public Guid AircraftId { get; set; }
        public string Manufacturer { get; set; }
        public string YearOfDelivery { get; set; }
        public string ModelName { get; set; }
        public string OwnerAirline { get; set; }
        public int FirstClassSeats { get; set; }
        public int BusinessClassSeats { get; set; }
        public int PremiumEconomyClassSeats { get; set; }
        public int EconomyClassSeats { get; set; }
    }

    public class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
    {
        public void Configure(EntityTypeBuilder<Aircraft> builder)
        {
            builder.HasKey(e => e.AircraftId);
            builder.Property(e => e.Manufacturer).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.YearOfDelivery).HasColumnType("varchar(4)").IsRequired();
            builder.Property(e => e.ModelName).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.OwnerAirline).HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}