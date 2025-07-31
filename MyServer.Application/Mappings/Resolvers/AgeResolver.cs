using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;
using System;

namespace MyServer.Application.Mappings.Resolvers
{
    public class AgeResolver : IValueResolver<Patient, PatientDto, string>,
                                IMemberValueResolver<Patient, PatientDto, object?, string>
    {
        public string Resolve(Patient source, PatientDto destination, string destMember, ResolutionContext context)
        {
            return CalculateAge(source.DateOfBirth);
        }

        public string Resolve(Patient source, PatientDto destination, object? sourceMember, string destMember, ResolutionContext context)
        {
            return CalculateAgeFull(source.DateOfBirth);
        }

        private string CalculateAge(int? yyyymmdd)
        {
            if (yyyymmdd is null || yyyymmdd == 0)
                return string.Empty;

            var dob = ParseDate(yyyymmdd.Value);
            var today = DateTime.Today;
            var years = today.Year - dob.Year;
            if (today < dob.AddYears(years)) years--;

            return $"{years}Y";
        }

        private string CalculateAgeFull(int? yyyymmdd)
        {
            if (yyyymmdd is null || yyyymmdd == 0)
                return string.Empty;

            var dob = ParseDate(yyyymmdd.Value);
            var today = DateTime.Today;

            var age = today - dob;
            var years = (int)(age.TotalDays / 365.25);
            var months = (int)((age.TotalDays % 365.25) / 30.4);
            var days = (int)((age.TotalDays % 365.25) % 30.4);

            return $"{years}Y-{months}M-{days}D";
        }

        private DateTime ParseDate(int yyyymmdd)
        {
            var year = yyyymmdd / 10000;
            var month = (yyyymmdd / 100) % 100;
            var day = yyyymmdd % 100;
            return new DateTime(year, month, day);
        }
    }
}
