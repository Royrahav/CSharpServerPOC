using AutoMapper;
using MyServer.Application.DTOs.Patients;
using MyServer.Application.Interfaces;

namespace MyServer.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> SearchPatientsAsync(string searchString)
        {
            var patients = await _patientRepository.SearchPatientsByIdentifierAsync(searchString);
            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }
    }
}
