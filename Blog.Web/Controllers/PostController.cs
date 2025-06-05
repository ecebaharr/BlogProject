using Blog.Core.Entities;
using Blog.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly PostRepository _postRepository;

        public PostController(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postRepository.GetAllAsync();
            return View(posts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            await _postRepository.CreateAsync(post);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
                return NotFound();

            return View(post);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _postRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
