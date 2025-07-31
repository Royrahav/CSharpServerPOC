using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;

public class IdentifiersResolver : IValueResolver<Patient, PatientDto, List<IdentifierDto>>
{
    public List<IdentifierDto> Resolve(Patient source, PatientDto destination, List<IdentifierDto> destMember, ResolutionContext context)
    {
        return new List<IdentifierDto>
        {
            new IdentifierDto
            {
                Code = 8,
                Name = "LAB#",
                Value = source.IID ?? "TST1363",
                ValueForDisplay = source.IID ?? "TST1363"
            },
            new IdentifierDto
            {
                Code = 14,
                Name = "Einat test",
                Value = "test",
                ValueForDisplay = "test"
            },
            new IdentifierDto
            {
                Code = 16,
                Name = "TEMP-CONST",
                Value = "189",
                ValueForDisplay = "189"
            }
        };
    }
}
