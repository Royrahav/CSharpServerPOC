using Microsoft.EntityFrameworkCore;
using MyServer.Application.Interfaces;
using MyServer.Domain.Entities;
using MyServer.Infrastructure.Persistence;

namespace MyServer.Infrastructure.Repositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly AppDbContext _context;

        public EpisodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Episode>> GetOpenEpisodesByPatientCodeAsync(int patientCode)
        {
            return await _context.Episodes
                .Where(e => e.PatientCode == patientCode &&
                            e.CloseDate == 0 &&
                            new[] { 1, 2, 3, 4, 12 }.Contains(e.Type))
                .OrderByDescending(e => e.Number)
                .ToListAsync();
        }

        public List<Episode> GetOpenEpisodesByPatientCode(int patientCode)
        {
            return _context.Episodes
                .Where(e => e.PatientCode == patientCode &&
                            e.CloseDate == 0 &&
                            new[] { 1, 2, 3, 4, 12 }.Contains(e.Type))
                .OrderByDescending(e => e.Number)
                .ToList();
        }
    }
}
