using MyServer.Application.DTOs.Patients;
using MyServer.Domain.Entities;

namespace MyServer.Application.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> SearchPatientsAsync(string searchString);
    }
}
