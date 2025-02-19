using DotaCup.API.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotaCup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClipsController : ControllerBase
    {
        private readonly IClipService _clipService;

        public ClipsController(IClipService clipService)
        {
            _clipService = clipService;
        }

        // GET: api/Clips
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _clipService.GetClips());
        }

        // GET: api/Clips/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _clipService.GetClip(id));
        }

        // GET: api/Clips/{id}/AddView
        [HttpPost("{id}/AddView")]
        public async Task<IActionResult> PostView(Guid id)
        {
            return Ok(await _clipService.AddView(id));
        }

        // GET: api/Clips/{id}/AddLike
        [HttpPost("{id}/AddLike")]
        public async Task<IActionResult> PostLike(Guid id)
        {
            return Ok(await _clipService.AddLike(id));
        }

        // GET: api/Clips/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _clipService.DeleteClip(id));
        }
    }
}
