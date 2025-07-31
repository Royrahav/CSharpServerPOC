using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;

namespace MyServer.Application.Mappings.Resolvers
{
    public class SexResolver : IValueResolver<Patient, PatientDto, SexDto?>
    {
        public SexDto? Resolve(Patient source, PatientDto destination, SexDto? destMember, ResolutionContext context)
        {
            return source.Sex switch
            {
                1 => new SexDto { Code = 1, Identifier = "MALE", Name = "Male" },
                2 => new SexDto { Code = 2, Identifier = "FEMALE", Name = "Female" },
                _ => null
            };
        }
    }
}
