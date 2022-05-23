using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VKPostsCharacterCounter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEventInfo action: {ex.Message}");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
