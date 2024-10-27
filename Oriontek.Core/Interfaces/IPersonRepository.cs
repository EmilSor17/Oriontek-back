using Oriontek.Core.Entities;


namespace Oriontek.Core.Interfaces
{
  public interface IPersonRepository : IRepository<Person>
  {
    Task<IEnumerable<dynamic>> GetAllPersonsWithDetailsAsync();
  }
}
