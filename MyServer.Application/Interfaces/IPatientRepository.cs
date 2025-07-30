using MyServer.Domain.Entities;

namespace MyServer.Application.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> SearchPatientsByIdentifierAsync(string searchString);
    }
}
