using Microsoft.AspNetCore.Mvc;
using MyServer.Application.Interfaces;
using MyServer.Application.Services;
using MyServer.Domain.Entities;

namespace MyServer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompositeController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IPerformanceService _performanceService;
        private readonly ILogger<CompositeController> _logger;

        public CompositeController(
            IPatientService patientService,
            IPerformanceService performanceService,
            ILogger<CompositeController> logger)
        {
            _patientService = patientService;
            _performanceService = performanceService;
            _logger = logger;
        }

        [HttpGet("performance-and-patient")]
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
    }
}