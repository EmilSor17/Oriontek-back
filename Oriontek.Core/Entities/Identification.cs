namespace Oriontek.Core.Entities
{
  public class Identification : BaseEntity
  {
    public string IdentificationNumber { get; set; }
    public int IdPerson { get; set; }
    public int IdentificationType { get; set; }
    public Person Person { get; set; }
  }
}
