using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConverter.Domain.Entities
{
    public partial class Pilot
    {
        public Guid PilotId { get; set; }
        public string Name { get; set; }
        public string AirLine { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
    }

    public class PilotConfiguration : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder.HasKey(e => e.PilotId);
            builder.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.AirLine).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.PhoneNumber).HasColumnType("varchar(10)").IsRequired();
            builder.Property(e => e.HomeAddress).HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}