using Oriontek.Core.Entities;
using Oriontek.Infratestructure.DTO;

public interface ICustomerService
{
  Task<IEnumerable<dynamic>> GetAllCustomersAsync();
  Task<Person> GetCustomerByIdAsync(int id);
  Task<(bool Created, bool Exists)> CreateCustomerAsync(CustomerDTO customerDTO);
  Task<bool> EditCustomerAsync(int id, Person updatedPerson, Address updatedAddress, Identification updatedIdentification);
  Task<bool> DeleteCustomerAsync(int id);
}
