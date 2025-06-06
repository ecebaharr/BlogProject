using Blog.Core.Entities;
using Blog.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostApiController : ControllerBase
    {
        private readonly PostRepository _postRepository;

        public PostApiController(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAll()
        {
            var posts = await _postRepository.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById(string id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Post post)
        {
            await _postRepository.CreateAsync(post);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Post post)
        {
            post.Id = id;
            await _postRepository.UpdateAsync(id, post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _postRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
