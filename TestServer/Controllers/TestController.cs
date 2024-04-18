using Microsoft.AspNetCore.Mvc;

namespace TestServer.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost("test-method")]
        public IActionResult Post(byte[] data)
        {
            return Ok();
        }
    }
}
