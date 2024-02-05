using LatencyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LatencyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LatencyController : ControllerBase
    {
        private readonly ILatencyService _latencyService;

        public LatencyController(ILatencyService latencyService)
        {
            _latencyService = latencyService;
        }

        [HttpGet]
        public ActionResult OkResult()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<HttpResponseMessage>> TestLatencyPostAsync([FromQuery] string requestUri)
        {
            return Ok(await _latencyService.TestLatencyPostAsync(requestUri));
        }

    }
}
