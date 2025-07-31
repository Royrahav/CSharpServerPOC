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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Patient>> SearchPatientsByIdentifierAsync(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return Enumerable.Empty<Patient>();

            var normalizedSearch = searchString.Trim().ToUpperInvariant();

            var results = await _context.Patients
                .Join(_context.PatientIdentifier,
                      patient => patient.Code,
                      ii => ii.Iicode,
                      (patient, ii) => new { patient, ii })
                .Where(x => x.ii.Iipid == searchString || x.ii.Iipid.StartsWith(searchString + "-"))
                .OrderBy(x => x.ii.Iipid)
                .ThenBy(x => x.patient.Code)
                .Select(x => x.patient)
                .Take(20)
                .ToListAsync();

             return results;
        }   

    }
}
