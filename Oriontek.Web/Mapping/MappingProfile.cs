using AutoMapper;
using Oriontek.Core.Entities;
using Oriontek.Infratestructure.DTO;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Person, PersonDTO>().ReverseMap();
    CreateMap<Address, AddressDTO>().ReverseMap();
    CreateMap<Identification, IdentificationDTO>().ReverseMap();
    CreateMap<IdGeneral, IdGeneralDTO>().ReverseMap();
    //CreateMap<CustomerDTO, Person>()
    //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AddressDTO))
    //    .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.IdentificationDTO))
    //    .ForMember(dest => dest.IdGeneral, opt => opt.MapFrom(src => src.IdGeneralDTO));
  }
}
