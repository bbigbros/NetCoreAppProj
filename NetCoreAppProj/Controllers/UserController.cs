namespace NetCoreAppProj.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NetCoreAppProj.Models.Identity;

    [Route("user")]
    public class UserController : Controller
    {
        [HttpPost("create-user")]
        public IActionResult CreateUser(
           [FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
