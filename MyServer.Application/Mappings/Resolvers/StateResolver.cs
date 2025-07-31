using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;

namespace MyServer.Application.Mappings.Resolvers
{
    public class StateResolver : IValueResolver<Patient, PatientDto, StateDto?>
    {
        public StateDto? Resolve(Patient source, PatientDto destination, StateDto? destMember, ResolutionContext context)
        {
            if (source.State is null)
                return null;

            return new StateDto
            {
                Code = source.State ?? 0,
                Name = "MockStateName",
                ShortName = "ST"
            };
        }
    }
}
