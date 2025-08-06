using Microsoft.AspNetCore.Mvc;
using MyServer.Application.Services;

namespace MyServer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerformanceAndPatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IPerformanceService _performanceService;
        private readonly ILogger<PerformanceAndPatientController> _logger;

        public PerformanceAndPatientController(
            IPatientService patientService,
            IPerformanceService performanceService,
            ILogger<PerformanceAndPatientController> logger)
        {
            _patientService = patientService;
            _performanceService = performanceService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientsAndRunPerformance([FromQuery] string searchString)
        {
            try
            {
                _logger.LogInformation("Starting composite operation: Patients search and Performance loop");

                // Step 1: Call Patient service
                _logger.LogDebug("Executing patient search for: {SearchString}", searchString);
                var patients = await _patientService.SearchPatientsAsync(searchString);
                var patientsList = patients.ToList();

                // Step 2: Call Performance service
                _logger.LogDebug("Starting performance loop");
                var performanceResult = await _performanceService.RunPerformanceLoop();

                // Return combined result
                var result = new
                {
                    Patients = patientsList,
                    PatientCount = patientsList.Count,
                    PerformanceResult = performanceResult,
                    ExecutedAt = DateTime.UtcNow
                };

                _logger.LogInformation("Composite operation completed successfully. Found {PatientCount} patients", patientsList.Count);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in composite operation for search string: {SearchString}", searchString);
                return StatusCode(500, "Internal server error during composite operation");
            }
        }

        [HttpGet("sync")]
        public IActionResult GetPatientsAndRunPerformanceSync([FromQuery] string searchString)
        {
            try
            {
                _logger.LogInformation("Starting composite operation: Patients search and Performance loop");

                // Step 1: Call Patient service
                _logger.LogDebug("Executing patient search for: {SearchString}", searchString);
                var patients = _patientService.SearchPatients(searchString);
                var patientsList = patients.ToList();

                // Step 2: Call Performance service
                _logger.LogDebug("Starting performance loop");
                var performanceResult = _performanceService.RunPerformanceLoop();

                // Return combined result
                var result = new
                {
                    Patients = patientsList,
                    PatientCount = patientsList.Count,
                    PerformanceResult = performanceResult,
                    ExecutedAt = DateTime.UtcNow
                };

                _logger.LogInformation("Composite operation completed successfully. Found {PatientCount} patients", patientsList.Count);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in composite operation for search string: {SearchString}", searchString);
                return StatusCode(500, "Internal server error during composite operation");
            }
        }
    }
}