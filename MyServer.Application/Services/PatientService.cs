using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Application.Interfaces;
using Microsoft.Extensions.Logging;
using MyServer.Domain.Entities;

namespace MyServer.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientService> _logger;

        public PatientService(IPatientRepository patientRepository,
            IEpisodeRepository episodeRepository,
            IMapper mapper,
            ILogger<PatientService> logger)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            _episodeRepository = episodeRepository ?? throw new ArgumentNullException(nameof(episodeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Patient>> SearchPatientsAsync(string searchString)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchString))
                {
                    _logger.LogDebug("Empty search string provided");
                    return Enumerable.Empty<Patient>();
                }

                var patients = await _patientRepository.SearchPatientsByIdentifierAsync(searchString);
                var patientsList = patients.ToList();

                if (!patientsList.Any())
                {
                    _logger.LogDebug("No patients found for search string: {SearchString}", searchString);
                    return Enumerable.Empty<Patient>();
                }

                //var patientDtos = _mapper.Map<IEnumerable<PatientDto>>(patientsList);

                foreach (var patient in patients)
                {
                    var episodes = await _episodeRepository.GetOpenEpisodesByPatientCodeAsync(patient.Code);
                    // Do something with episodes — e.g., log, inspect, later assign
                }

                _logger.LogDebug("Successfully found {Count} patients for search string: {SearchString}",
                    patientsList.Count, searchString);

                return patients;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching patients with search string: {SearchString}", searchString);
                throw;
            }
        }
    }
}
