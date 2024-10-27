using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oriontek.Core.Entities;

namespace Oriontek.Infraestructure.Data.Configurations
{
  public class AddressConfiguration : IEntityTypeConfiguration<Address>
  {
    public void Configure(EntityTypeBuilder<Address> builder)
    {
      builder.ToTable("Direcciones");
      builder.HasKey(d => d.Id);

      builder.Property(d => d.IdPerson)
          .IsRequired();

      builder.Property(d => d.House)
          .HasMaxLength(50);

      builder.Property(d => d.Street)
          .HasMaxLength(100);

      builder.Property(d => d.Neighborhood)
          .HasMaxLength(50);

      builder.Property(d => d.Country)
          .HasMaxLength(50);

      builder.HasOne(d => d.Person)
             .WithOne(p => p.Address)
             .HasForeignKey<Address>(a => a.IdPerson)
             .OnDelete(DeleteBehavior.Restrict);
    }
  }

}
