using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTtoken.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly JWTTokenGenerator tokenGenerator;

        public ValuesController(JWTTokenGenerator tokenGenerator)
        {
            this.tokenGenerator = tokenGenerator;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var token = tokenGenerator.GetToken();
            return Ok(token);
        }
    }
}
