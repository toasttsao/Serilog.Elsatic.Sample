using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Serilog.Elsatic.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogSampleTestController : ControllerBase
    {
    

        private readonly ILogger<LogSampleTestController> _logger;

        public LogSampleTestController(ILogger<LogSampleTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var logObj = new
            {
                name="toast",
                height=170,
                weight="secret",
                address="secret"
            };
            _logger.LogError(JsonConvert.SerializeObject(logObj));
            
            return Ok();
        }
    }
}