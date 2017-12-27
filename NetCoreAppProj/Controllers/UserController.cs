namespace NetCoreAppProj.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NetCoreAppProj.Models;
    using NetCoreAppProj.Models.Identity;

    [Route("user")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

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
