using Microsoft.EntityFrameworkCore;
using MyServer.Application.Interfaces;
using MyServer.Domain.Entities;
using MyServer.Infrastructure.Persistence;

namespace MyServer.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> SearchPatientsByIdentifierAsync(string searchString)
        {
            return await _context.Patients
            .Where(p => p.Identifiers.Any(id =>
                EF.Functions.Like(id.Value, $"%{searchString}%")))
            .Include(p => p.Identifiers)
            .ToListAsync();
        }

    }
}
