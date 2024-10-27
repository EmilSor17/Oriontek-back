namespace Oriontek.Core.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    IAddressRepository Address { get; }
    IIdentificationRepository Identification { get; }
    IPersonRepository Person { get; }
    IGeneralRepository General { get; }
    Task<int> Complete();
  }
}
