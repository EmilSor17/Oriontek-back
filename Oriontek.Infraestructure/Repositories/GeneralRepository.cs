using Oriontek.Core.Entities;
using Oriontek.Core.Interfaces;
using Oriontek.Infraestructure.Data;

namespace Oriontek.Infraestructure.Repositories
{
  public class GeneralRepository : BaseRepository<IdGeneral>, IGeneralRepository
  {
    public GeneralRepository(DatContext context) : base(context)
    {
    }
  }
}
