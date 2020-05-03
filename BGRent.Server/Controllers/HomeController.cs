namespace BGRent.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ControllerBase
    {
        [Authorize]
        [Route("[controller]")]
        public ActionResult Get()
        {
            return Ok("Works");
        }
    }
}
