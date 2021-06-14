using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BlogLab.Model.Blog;
using BlogLab.Model.BlogComment;
using BlogLab.Model.Photo;
using BlogLab.Repository;
using BlogLab.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogLab.Web.Controllers
{
  [Route("api/[controller]")]
  public class BlogCommentController : Controller
  {
    private readonly IBlogCommentRepository _blogCommentRepository;

    public BlogCommentController(IBlogCommentRepository blogCommentRepository)
    {
      _blogCommentRepository = blogCommentRepository;
    }


    [Authorize]
    [HttpPost]
    public async Task<ActionResult<BlogComment>> Create(BlogCommentCreate blogCommentCreate)
    {
      int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

      var createdBlogComment = await _blogCommentRepository.UpsertAsync(blogCommentCreate, applicationUserId);

      return Ok(createdBlogComment);
    }

    [HttpGet("{blogId}")]
    public async Task<ActionResult<List<BlogComment>>> GetAll(int blogId)
    {
      var blogComments = await _blogCommentRepository.GetAllAsync(blogId);

      return Ok(blogComments);
    }


    [Authorize]
    [HttpDelete("{blogCommentId}")]
    public async Task<ActionResult<int>> Delete(int blogCommentId)
    {
      int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

      var foundBlogComment = await _blogCommentRepository.GetAsync(blogCommentId);

      if (foundBlogComment == null) return BadRequest("Comment does not exist");

      if (foundBlogComment.ApplicationUserId == applicationUserId)
      {
        var affectedRows = await _blogCommentRepository.DeleteAsync(blogCommentId);

        return Ok(affectedRows);
      }
      else
      {
        return BadRequest("This comment was not created by the current user.");
      }

    }




  }
}
