using System;
using System.Collections.Generic;
using VKPostsCharacterCounter.Services;
using Microsoft.AspNetCore.Mvc;

namespace VKPostsCharacterCounter.Controllers
{
    [Route("api/char-statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ILogger<StatisticsController> _logger;
        private PostsService _searcher;

        public StatisticsController(ILogger<StatisticsController> logger, PostsService searcher)
        {
            _logger = logger;
            _searcher = searcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharStatistic()
        {
            try
            {
                var list = await _searcher.CharCount();
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something wrong inside GetCharStatistic action: {ex.Message}");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
