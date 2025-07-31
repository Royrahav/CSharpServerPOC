using Microsoft.AspNetCore.Mvc;
using MyServer.Application.Services;
using System.Threading.Tasks;

namespace MyServer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients([FromQuery] string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return BadRequest("Search string cannot be empty");

            if (searchString.Length < 2)
                return BadRequest("Search string must be at least 2 characters");

            var result = await _patientService.SearchPatientsAsync(searchString.Trim());
            return Ok(result);
        }
    }
}
