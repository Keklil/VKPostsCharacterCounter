using System;
using System.Collections.Generic;
using VKPostsCharacterCounter.Services;
using VKPostsCharacterCounter.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VkNet;
using VkNet.Model;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace VKPostsCharacterCounter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private PostsService _searcher;

        public ValuesController(ILogger<ValuesController> logger, PostsService searcher)
        {
            _logger = logger;
            _searcher = searcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _searcher.Search();
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEventInfo action: {ex.Message}");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
