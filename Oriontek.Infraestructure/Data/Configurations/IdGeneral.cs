using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oriontek.Core.Entities;

namespace Oriontek.Infraestructure.Data.Configurations
{
  public class IdGeneralConfiguration : IEntityTypeConfiguration<IdGeneral>
  {
    public void Configure(EntityTypeBuilder<IdGeneral> builder)
    {
      builder.ToTable("IdGeneral");
      builder.HasKey(ig => ig.Id);

      builder.Property(ig => ig.IdPerson)
          .IsRequired();

      builder.HasOne(ig => ig.Person)
             .WithOne(p => p.IdGeneral)
             .HasForeignKey<IdGeneral>(ig => ig.IdPerson)
             .OnDelete(DeleteBehavior.Restrict);  // Cambiado a Restrict
    }
  }

}
