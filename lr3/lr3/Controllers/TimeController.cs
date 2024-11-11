using Microsoft.AspNetCore.Mvc;
using lr3.Services;

namespace lr3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        private readonly TimeService _timeService;

        public TimeController(TimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet("current-time-period")]
        public IActionResult GetCurrentTimePeriod() => Ok(_timeService.GetCurrentTimePeriod());
    }
}
