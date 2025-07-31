using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;

public class CityResolver : IValueResolver<Patient, PatientDto, CityDto?>
{
    public CityDto? Resolve(Patient source, PatientDto destination, CityDto? destMember, ResolutionContext context)
    {
        if (source.City is null && string.IsNullOrWhiteSpace(source.ICityN))
            return null;

        return new CityDto
        {
            Code = source.City ?? 0,
            Name = source.ICityN ?? string.Empty
        };
    }
}
