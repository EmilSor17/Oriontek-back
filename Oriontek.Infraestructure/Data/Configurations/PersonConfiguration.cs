using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oriontek.Core.Entities;

namespace Oriontek.Infraestructure.Data.Configurations
{
  public class PersonConfiguration : IEntityTypeConfiguration<Person>
  {
    public void Configure(EntityTypeBuilder<Person> builder)
    {
      builder.ToTable("Personas");
      builder.HasKey(p => p.Id);

      builder.HasOne(p => p.Address)
             .WithOne(a => a.Person)
             .HasForeignKey<Address>(a => a.IdPerson)
             .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(p => p.Identification)
             .WithOne(i => i.Person)
             .HasForeignKey<Identification>(i => i.IdPerson)
             .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(p => p.IdGeneral)
             .WithOne(ig => ig.Person)
             .HasForeignKey<IdGeneral>(ig => ig.IdPerson)
             .OnDelete(DeleteBehavior.Cascade);
    }
  }

}
