
namespace Oriontek.Core.Entities
{
  public class Person : BaseEntity
  {
    public int IdPerson { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public Address Address { get; set; }
    public Identification Identification { get; set; }
    public IdGeneral IdGeneral { get; set; }
  }
}
