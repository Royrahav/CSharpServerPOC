using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;
using System;

namespace MyServer.Application.Mappings.Resolvers
{
    public class BirthDateResolver : IValueResolver<Patient, PatientDto, BirthDateDto?>
    {
        public BirthDateDto? Resolve(Patient source, PatientDto destination, BirthDateDto? destMember, ResolutionContext context)
        {
            if (!source.DateOfBirth.HasValue || source.DateOfBirth == 0)
                return null;

            var dob = ParseDateFromInt(source.DateOfBirth.Value);

            return new BirthDateDto
            {
                DateTime = dob.ToString("dd-MM-yyyy"),
                FormattedDate = dob.ToString("dd/MM/yyyy")
            };
        }

        private DateTime ParseDateFromInt(int yyyymmdd)
        {
            var year = yyyymmdd / 10000;
            var month = (yyyymmdd / 100) % 100;
            var day = yyyymmdd % 100;

            return new DateTime(year, month, day);
        }
    }
}
