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
            return name switch
            {
                //if name == John return 200 else return bad request
                "Homer" => Ok("Hello Homer!"),
                "Marge" => Ok("Hello Marge!"),
                "Bart" => Ok("Hello Bart!"),
                "Lisa" => Ok("Hello Lisa!"),
                "Maggie" => Ok("Hello Maggie!"),
                _ => BadRequest("You are not a Simpson!")
            };
        }
    }
}
