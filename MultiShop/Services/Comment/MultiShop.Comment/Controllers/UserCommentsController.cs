using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public UserCommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var value = _context.UserComments.Find(id);
            return Ok(value);
        }

        [HttpGet("GetCommentListByProductId/{id}")]
        public IActionResult GetCommentListByProductId(string id)
        {
            var value = _context.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            _context.SaveChanges();
            return Ok("Yorum başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var value = _context.UserComments.Find(id);
            _context.UserComments.Remove(value);
            _context.SaveChanges();
            return Ok("Yorum başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
            return Ok("Yorum başarıyla güncellendi!");
        }
    }
}
