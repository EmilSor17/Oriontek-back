using Oriontek.Core.Entities;
using Oriontek.Core.Interfaces;
using Oriontek.Infraestructure.Data;

namespace Oriontek.Infraestructure.Repositories
{
  public class IdentificationRepository : BaseRepository<Identification>, IIdentificationRepository
  {
    public IdentificationRepository(DatContext context) : base(context)
    {
    }
  }
}
