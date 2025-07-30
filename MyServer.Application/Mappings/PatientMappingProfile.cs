using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;

namespace MyServer.Application.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<City, CityDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<State, StateDto>();
            CreateMap<BirthDate, BirthDateDto>();
            CreateMap<Sex, SexDto>();
            CreateMap<Identifier, IdentifierDto>();
            CreateMap<DefaultIdType, DefaultIdTypeDto>();
        }
    }
}
