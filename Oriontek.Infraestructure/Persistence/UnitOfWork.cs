using Oriontek.Core.Interfaces;
using Oriontek.Infraestructure.Data;
using Oriontek.Infraestructure.Repositories;

namespace Oriontek.Infraestructure.Persistence
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DatContext _Context;
    public UnitOfWork(DatContext Context)
    {
      _Context = Context;

      Person = new PersonRepository(_Context);
      Address = new AddressRepository(_Context);
      General = new GeneralRepository(_Context);
      Identification = new IdentificationRepository(_Context);
    }
    public IPersonRepository Person { get; private set; }
    public IAddressRepository Address { get; private set; }
    public IGeneralRepository General { get; private set; }
    public IIdentificationRepository Identification { get; private set; }

    public async Task<int> Complete()
    {
      return await _Context.SaveChangesAsync();
    }

    public void Dispose()
    {
      _Context.Dispose();
    }
  }
}