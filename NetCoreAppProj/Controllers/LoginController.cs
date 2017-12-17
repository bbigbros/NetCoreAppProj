namespace NetCoreAppProj.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using NetCoreAppProj.Models.Identity;

    [Route("user")]
    public class LoginController : Controller
    {
       [HttpPost("create-user")]
       public IActionResult CreateUser(
           [FromBody]User user)
        {
            Console.WriteLine("CreateUser Action!");
            return Ok();
        }
    }
}
