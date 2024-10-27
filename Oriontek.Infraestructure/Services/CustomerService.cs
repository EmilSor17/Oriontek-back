using AutoMapper;
using Oriontek.Core.Entities;
using Oriontek.Core.Interfaces;
using Oriontek.Infratestructure.DTO;

public class CustomerService : ICustomerService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public CustomerService(IUnitOfWork unitOfWork, IMapper mapper) 
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }
  
    

  public async Task<IEnumerable<dynamic>> GetAllCustomersAsync()
  {
    var people = await _unitOfWork.Person.GetAllPersonsWithDetailsAsync();
    return people;
  }

  public async Task<Person> GetCustomerByIdAsync(int id)
  {
    return await _unitOfWork.Person.GetByIdWithIncludesAsync(id, "Address", "Identification");
  }

  public async Task<bool> EditCustomerAsync(int id, Person updatedPerson, Address updatedAddress, Identification updatedIdentification)
  {
    var existingPerson = await _unitOfWork.Person.GetByIdAsync(id);
    if (existingPerson == null) return false;

    existingPerson.Name = updatedPerson.Name;
    existingPerson.LastName = updatedPerson.LastName;
    existingPerson.Phone = updatedPerson.Phone;
    _unitOfWork.Person.Update(existingPerson);

    var existingAddress = await _unitOfWork.Address.GetByIdAsync(id);
    if (existingAddress != null)
    {
      existingAddress.House = updatedAddress.House;
      existingAddress.Street = updatedAddress.Street;
      existingAddress.Neighborhood = updatedAddress.Neighborhood;
      existingAddress.Country = updatedAddress.Country;
      _unitOfWork.Address.Update(existingAddress);
    }

    var existingIdentification = await _unitOfWork.Identification.GetByIdAsync(id);
    if (existingIdentification != null)
    {
      existingIdentification.IdentificationNumber = updatedIdentification.IdentificationNumber;
      existingIdentification.IdentificationType = updatedIdentification.IdentificationType;
      _unitOfWork.Identification.Update(existingIdentification);
    }

    await _unitOfWork.Complete();
    return true;
  }

  public async Task<bool> DeleteCustomerAsync(int id)
  {
    var person = await _unitOfWork.Person.GetByIdAsync(id);
    if (person == null) return false;

    await _unitOfWork.Person.DeleteAsync(id);    
    await _unitOfWork.Complete();

    return true;
  }

  public async Task<(bool Created, bool Exists)> CreateCustomerAsync(CustomerDTO customerDTO)
  {
    
    var existingCustomer = await _unitOfWork.Identification.FindAsync(i => i.IdentificationNumber == customerDTO.IdentificationDTO.IdentificationNumber);

    if (existingCustomer != null)
    {
      return (Created: false, Exists: true);
    }

    
    var person = new Person
    {
      Name = customerDTO.PersonDTO.Name,
      LastName = customerDTO.PersonDTO.LastName,
      Phone = customerDTO.PersonDTO.Phone
    };

    
    await _unitOfWork.Person.AddAsync(person);
    await _unitOfWork.Complete();

    
    var address = new Address
    {
      IdPerson = person.Id, 
      House = customerDTO.AddressDTO.House,
      Street = customerDTO.AddressDTO.Street,
      Neighborhood = customerDTO.AddressDTO.Neighborhood,
      Country = customerDTO.AddressDTO.Country
    };

    var identification = new Identification
    {
      IdPerson = person.Id, 
      IdentificationNumber = customerDTO.IdentificationDTO.IdentificationNumber,
      IdentificationType = customerDTO.IdentificationDTO.IdentificationType
    };

    var idGeneral = new IdGeneral
    {
      IdPerson = person.Id 
    };

    
    await _unitOfWork.Address.AddAsync(address);
    await _unitOfWork.Identification.AddAsync(identification);
    await _unitOfWork.General.AddAsync(idGeneral);

    
    var result = await _unitOfWork.Complete();
    return (Created: result != 0, Exists: false);
  }




}
