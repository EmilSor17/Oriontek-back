using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oriontek.Core.Entities;
using Oriontek.Infratestructure.DTO;

namespace Oriontek.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomerController : ControllerBase
  {
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
      _customerService = customerService;
      _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<dynamic>>> GetAll()
    {
      var customers = await _customerService.GetAllCustomersAsync();
      return Ok(customers);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDTO>> GetById(int id)
    {
      var customer = await _customerService.GetCustomerByIdAsync(id);
      if (customer == null) return NotFound();

      var customerDto = _mapper.Map<CustomerDTO>(customer);
      return Ok(customerDto);
    }


    [HttpPost]
    public async Task<ActionResult> Create(CustomerDTO customerDto)
    {
      var (created, exists) = await _customerService.CreateCustomerAsync(customerDto);

      if (exists)
      {
        return Conflict("Ya existe un cliente con el número de identificación proporcionado.");
      }

      if (!created)
      {
        return BadRequest("No se pudo crear el cliente");
      }

      return Ok("Cliente creado con éxito");
    }



    [HttpPut("{id}")]
    public async Task<ActionResult> Edit(int id, CustomerDTO customerDto)
    {
      var person = _mapper.Map<Person>(customerDto.PersonDTO);
      var address = _mapper.Map<Address>(customerDto.AddressDTO);
      var identification = _mapper.Map<Identification>(customerDto.IdentificationDTO);

      var updated = await _customerService.EditCustomerAsync(id, person, address, identification);
      if (!updated) return NotFound("No se encontro el cliente");

      return Ok("Cliente actualizado");
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var deleted = await _customerService.DeleteCustomerAsync(id);
      if (!deleted) return NotFound("No se encontro el cliente");

      return Ok(deleted);
    }
  }
}
