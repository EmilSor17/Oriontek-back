namespace Oriontek.Core.Entities
{
  public class Address : BaseEntity
  {
    public int IdPerson { get; set; }
    public string House { get; set; }
    public string Street { get; set; }
    public string Neighborhood { get; set; }
    public int Country { get; set; }
    public Person Person { get; set; }
  }
}
