using Microsoft.EntityFrameworkCore;
using Oriontek.Core.Entities;
using System.Reflection;

namespace Oriontek.Infraestructure.Data
{
  public class DatContext : DbContext
  {
    public DatContext()
    {

    }
    public DatContext(DbContextOptions<DatContext> options)
        : base(options)
    {

    }
    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<Address> Address { get; set; }
    public virtual DbSet<Identification> Identifications { get; set; }
    public virtual DbSet<IdGeneral> IdGenerals { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}
