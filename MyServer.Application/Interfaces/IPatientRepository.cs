using MyServer.Domain.Entities;
using MyServer.Application.DTOs.Patients;

namespace MyServer.Application.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> SearchPatientsByIdentifierAsync(string searchString);
        IEnumerable<Patient> SearchPatientsByIdentifier(string searchString);

    }
}
