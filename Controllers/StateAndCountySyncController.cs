using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Interfaces;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateAndCountySyncController : ControllerBase
    {
        private readonly IGeoEntityService _geoEntityService;

        public StateAndCountySyncController(IGeoEntityService geoEntityService)
        {
            _geoEntityService = geoEntityService;
        }

        [HttpPost]
        public IActionResult SyncStateAndCounty()
        {
            try
            {
                _geoEntityService.MergeStateDetails();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCurrentEnvironment()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return Ok(environment);
        }

    }
}
