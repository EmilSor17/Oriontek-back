using Oriontek.Core.Entities;
using Oriontek.Core.Interfaces;
using Oriontek.Infraestructure.Data;

namespace Oriontek.Infraestructure.Repositories
{
  public class AddressRepository : BaseRepository<Address>, IAddressRepository
  {
    public AddressRepository(DatContext context) : base(context)
    {
    }
  }
}
