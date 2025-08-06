using Microsoft.AspNetCore.Mvc;
using MyServer.Application.Interfaces;
using MyServer.Application.Services;

namespace MyServer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerformanceController : ControllerBase
    {
        private readonly IPerformanceService _performanceService;

        public PerformanceController(IPerformanceService performanceService)
        {
            _performanceService = performanceService;
        }
            [HttpGet]
        public async Task<IActionResult> StartPerformanceLoop()
        {
            var result = await _performanceService.RunPerformanceLoop();
            return Ok(result);
        }
    }
}
