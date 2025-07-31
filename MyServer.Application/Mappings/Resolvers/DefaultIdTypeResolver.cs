using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;

namespace MyServer.Application.Mappings.Resolvers
{
    public class DefaultIdTypeResolver : IValueResolver<Patient, PatientDto, DefaultIdTypeDto?>
    {
        public DefaultIdTypeDto? Resolve(Patient source, PatientDto destination, DefaultIdTypeDto? destMember, ResolutionContext context)
        {
            if (source.IdType is null)
                return null;

            return new DefaultIdTypeDto
            {
                Code = source.IdType.Value,
                Name = "LAB#" // mock for now
            };
        }
    }
}
