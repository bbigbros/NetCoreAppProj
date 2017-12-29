namespace NetCoreAppProj.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using NetCoreAppProj.Models;
    using NetCoreAppProj.Models.Board;

    [Route("post")]
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PostController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_dbContext.Posts.ToList());
        }

        [HttpGet("/post/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/post/postcreated")]
        public IActionResult PostCreated(
            [FromForm]Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }

            Console.WriteLine(post.Author == null ? "null!" : "Notnull");
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
