using MyServer.Domain.Entities;

namespace MyServer.Application.Interfaces
{
    public interface IEpisodeRepository
    {
        Task<List<Episode>> GetOpenEpisodesByPatientCodeAsync(int patientCode);
        List<Episode> GetOpenEpisodesByPatientCode(int patientCode);
    }
}
