using Microsoft.AspNetCore.Mvc;
using MyServer.Application.Services;
using MyServer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace MyServer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IRedisConfigService _redisConfigService;
        // For Redis Mock
        private readonly string _redisPrefix;
        private readonly string[] _configKeys;

        public PatientsController(IPatientService patientService, IRedisConfigService redisConfigService)
        {
            _redisPrefix = "SRVSQL2016_Nightly_Sync_LabOS_env_qa_CONFIG_";
            _configKeys = new[]
            {
                "FILTER_BY_PATIENT_SITE",
                "CHECKSUM_SEPERATOR_FOR_DISPLAY",
                "CHECKSUM_SEPERATOR_FOR_SAVE",
                "USE_SENDER_EPISODE_FOR_PATIENT",
                "SEARCH_PATIENT_BY_HOSPITALIZATION",
                "SEARCH_PATIENT_BY_HAS_ORDERS_DAYS_BACK",
                "SEARCH_PATIENTS_BY_VIEW",
                "PATIENT_SEARCH_FILTER_CONTAINS",
                "EXECUTE_DEMOG_WITH_EPISODE",
                "EXECUTE_DEMOG_POLICY",
                "RESOURCES_USED_RO_DB",
                "PRIMARY_ID_TYPE",
                "RECORD_SEARCH_ON_ALL_PATIENT_FIELDS",
                "IGNORE_ASSOCIATION_TO_SENDER",
                "ENABLE_QUERIES_ROWS_LIMIT",
                "CHARACTERS_TO_REPLACE_WITH_SPACE_IN_SEARCH",
                "PATIENT_CHECKSUM_IDTYPE_SEARCH_LOGIC",
                "MAXIMUM_DIGITS_FOR_PHONE",
                "NAMES_DISPLAY_ORDER",
                "WEB_EPISODE_TYPES"
            };

            _patientService = patientService;
            _redisConfigService = redisConfigService;


        }

        [HttpGet]
        public async Task<IActionResult> GetPatients([FromQuery] string searchString)
        {
            var fullKeys = _configKeys.Select(k => _redisPrefix + k).ToArray();
            var configs = await _redisConfigService.LoadConfigsAsync(fullKeys);
            foreach (var config in configs)
                //Console.WriteLine($"{config.Key} => Exists: {config.Exists}, Value: {config.Value}");
                continue;

            if (string.IsNullOrWhiteSpace(searchString))
                return BadRequest("Search string cannot be empty");

            if (searchString.Length < 2)
                return BadRequest("Search string must be at least 2 characters");

            var result = await _patientService.SearchPatientsAsync(searchString.Trim());
            return Ok(result);
        }
    }
}
