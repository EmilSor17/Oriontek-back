using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oriontek.Core.Entities;

namespace Oriontek.Infraestructure.Data.Configurations
{
  public class IdentificationConfiguration : IEntityTypeConfiguration<Identification>
  {
    public void Configure(EntityTypeBuilder<Identification> builder)
    {
      builder.ToTable("Identificaciones");
      builder.HasKey(i => i.Id);

      builder.Property(i => i.IdentificationNumber)
          .IsRequired()
          .HasMaxLength(50);

      builder.Property(i => i.IdPerson)
          .IsRequired();

      builder.Property(i => i.IdentificationType)
          .IsRequired()
          .HasMaxLength(20);

      builder.HasOne(i => i.Person)
             .WithOne(p => p.Identification)
             .HasForeignKey<Identification>(i => i.IdPerson)
             .OnDelete(DeleteBehavior.Restrict);  // Cambiado a Restrict
    }
  }

}
