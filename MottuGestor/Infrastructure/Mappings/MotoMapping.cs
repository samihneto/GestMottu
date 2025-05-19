using GestMottu.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MottuGestor.Domain.Entities;

namespace MottuGestor.Infrastructure.Mappings
{
    public class MotoMapping : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.ToTable("MOTO");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(m => m.Modelo)
                   .HasColumnName("MODELO")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(m => m.Placa)
                   .HasColumnName("PLACA")
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(m => m.Status)
                   .HasColumnName("STATUS")
                   .HasConversion<string>()
                   .IsRequired();
        }
    }
}