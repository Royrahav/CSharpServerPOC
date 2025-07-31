using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Application.Mappings.Resolvers;
using MyServer.Domain.Entities;

namespace MyServer.Application.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, PatientDto>();

            // Data resolvers
            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.Sex, opt => opt.MapFrom<SexResolver>())
                .ForMember(dest => dest.Address, opt => opt.MapFrom<AddressResolver>())
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom<BirthDateResolver>())
                .ForMember(dest => dest.Age, opt => opt.MapFrom<AgeResolver>())
                .ForMember(dest => dest.AgeFull, opt => opt.MapFrom((src, dest, _, ctx) => new AgeResolver().Resolve(src, dest, null, string.Empty, ctx)))
                .ForMember(dest => dest.DefaultIdType, opt => opt.MapFrom<DefaultIdTypeResolver>())
                .ForMember(dest => dest.DefaultId, opt => opt.MapFrom(src => src.IID ?? string.Empty))
                .ForMember(dest => dest.Ids, opt => opt.MapFrom<IdentifiersResolver>())
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                    string.Join(" ", new[] { src.FirstName, src.MiddleName, src.LastName }
                        .Where(name => !string.IsNullOrWhiteSpace(name)))
                ))
                .ForMember(dest => dest.BirthYear, opt => opt.MapFrom(src =>
                    src.DateOfBirth.HasValue && src.DateOfBirth != 0
                        ? src.DateOfBirth.Value / 10000
                        : 0
                ))
;
        }
    }
}
