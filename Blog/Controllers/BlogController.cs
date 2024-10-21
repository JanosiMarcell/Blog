using Blog.Migrations;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using static Blog.Models.Dto;

namespace Blog.Controllers
{
    [Route("blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Blogger> Get()
        {
            using (var context = new BlogDbContext())
            {

                    return Ok(context.Bloggers.ToList());
            }

        }
        [HttpPost]
        public ActionResult<Blogger> Post(CreateBloggerDto blogerDto)
        {
            return Ok();
    }
    }
}
