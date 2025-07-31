using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;

namespace MyServer.Application.Mappings.Resolvers
{
    public class CountryResolver : IValueResolver<Patient, PatientDto, CountryDto?>
    {
        public CountryDto? Resolve(Patient source, PatientDto destination, CountryDto? destMember, ResolutionContext context)
        {
            if (source.Country is null)
                return null;

            return new CountryDto
            {
                Code = source.Country ?? 0,
                Name = "MockCountryName"
            };
        }
    }
}
