using Microsoft.AspNetCore.Mvc;

namespace LearnHowToWriteTests.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Hello World!");
        }

        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            //if name == John return 200 else return bad request
            if (name == "John")
            {
                return Ok("Hello John!");
            }

            return BadRequest("Name is not John");
        }
    }
}
