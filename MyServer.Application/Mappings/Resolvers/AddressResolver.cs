using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;

namespace MyServer.Application.Mappings.Resolvers
{
    public class AddressResolver : IValueResolver<Patient, PatientDto, AddressDto>
    {
        public AddressDto Resolve(Patient source, PatientDto destination, AddressDto destMember, ResolutionContext context)
        {
            return new AddressDto
            {
                Street1 = source.Str1 ?? string.Empty,
                Street2 = source.Str2 ?? string.Empty,
                Street3 = source.Str3 ?? string.Empty,
                Zip = source.Zip ?? string.Empty,
                Email = source.Email ?? string.Empty,
                Fax = source.Fax ?? string.Empty,
                Phone1 = source.Phone ?? string.Empty,
                Phone2 = source.Mobile ?? string.Empty,
                Extension = source.PhoneExt ?? 0,

                // Temporary placeholders — will be filled by dedicated resolvers later
                City = new CityResolver().Resolve(source, destination, null, context),
                State = new StateResolver().Resolve(source, destination, null, context),
                Country = new CountryResolver().Resolve(source, destination, null, context),
            };
        }
    }
}
