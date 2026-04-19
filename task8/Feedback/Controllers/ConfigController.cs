using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Feedback.Options;

namespace Feedback.Controllers
{
    [ApiController]
    [Route("config")]
    public class ConfigController : ControllerBase
    {
        public IConfiguration _configuration;
        public IOptions<SystemSettingsOptions> _options;
        public ConfigController(IConfiguration configuration , IOptions<SystemSettingsOptions> options)
        {
            _configuration = configuration;
            _options = options;
        }
        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            var configuration = new
            {
                SystemSettings = _options.Value
            };
            return Ok(configuration);
        }
    }
}