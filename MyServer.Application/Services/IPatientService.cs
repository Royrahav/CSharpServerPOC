using MyServer.Application.DTOs.Patients;

namespace MyServer.Application.Services
{
    public class IPatientService
    {
        Task<IEnumerable<PatientDto>> SearchPatientsAsync(string searchString);
    }
}
