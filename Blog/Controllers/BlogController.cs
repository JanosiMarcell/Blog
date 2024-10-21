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
        [HttpGet("{id}")]
        public ActionResult<Blogger> GetBId(Guid id) 
        {
            using (var context = new BlogDbContext())
            { 
                var blogger=context.Bloggers.FirstOrDefault(b => b.Id == id);
                if (blogger != null)
                {
                    return StatusCode(200, blogger);
                }
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult<Blogger> Post(CreateBloggerDto createBloggerDto)
        {
            using (var context = new BlogDbContext())
            {
                var blogger = new Blogger()
                {
                    Id = Guid.NewGuid(),
                    Name = createBloggerDto.Name,
                    Sex = createBloggerDto.Sex,
                    Status="Waiting",
                    RegistrationTime=DateTime.Now,
                };
                if (blogger != null)
                {
                    context.Bloggers.Add(blogger);
                    context.SaveChanges();
                    return StatusCode(201, blogger);
                }
            }
            return Ok();
    }
    }
}
