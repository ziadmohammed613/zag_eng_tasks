using Microsoft.AspNetCore.Mvc;
using Feedback.DTOs;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Feedback.Options;

namespace Feedback.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        public readonly ILogger<PostsController> _logger;
        public IOptions<SystemSettingsOptions> _options;
        public PostsController(ILogger<PostsController> logger, IOptions<SystemSettingsOptions> options)
        {
            _logger = logger;
            _options = options;
        }
        [HttpPost]
        [Route("")]
        public ActionResult Post([FromBody] PostDTO post,
            [FromQuery(Name = "rate")] int rate)
        {
            post.Rate = rate;
            string json = JsonSerializer.Serialize(post , new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText("DumpData/Posts.json", json);
            return Ok();
        }
        [HttpGet]
        [Route("{userName}")]
        public ActionResult Get(string userName)
        {
            string json = System.IO.File.ReadAllText("DumpData/Posts.json");
            PostDTO post = JsonSerializer.Deserialize<PostDTO>(json);
            if (post.Rate < 3)
                _logger.LogWarning("User {UserName} gave a low rating of {Rate}", post.UserName, post.Rate);
            return Ok($"Feedback received for {_options.Value.SystemName}. Thank you, {post.UserName}!");
        }
    }
}