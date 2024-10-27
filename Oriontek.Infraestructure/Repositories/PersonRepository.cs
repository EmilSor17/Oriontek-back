using Microsoft.EntityFrameworkCore;
using Oriontek.Core.Entities;
using Oriontek.Core.Interfaces;
using Oriontek.Infraestructure.Data;
using Oriontek.Infratestructure.DTO;

namespace Oriontek.Infraestructure.Repositories
{
  public class PersonRepository : BaseRepository<Person>, IPersonRepository
  {
    private readonly DatContext _context;

    public PersonRepository(DatContext context) : base(context)
    {
      _context = context;
    }

    public async Task<IEnumerable<dynamic>> GetAllPersonsWithDetailsAsync()
    {
      var persons = await _context.People
          .Select(p => new
          {
            p.Id,
            p.Name,
            p.LastName,
            p.Phone,
            p.Identification,
            p.Address
          }).ToListAsync();
      return persons;
    }
  }
}
