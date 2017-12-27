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

        public IEnumerable<Post> Index()
        {
            return _dbContext.Posts.ToList();
        }

        [HttpPost("create")]
        public IActionResult Create(
            [FromBody]Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
