using Microsoft.AspNetCore.Mvc;

namespace RailLate.Controllers;

[Route("api/[controller]")]
public class TestController : ControllerBase
{

    [Route("test")]
    public ActionResult? Test()
    {
        return Ok();
    }
}