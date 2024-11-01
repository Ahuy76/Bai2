using Microsoft.AspNetCore.Mvc;
using SuKien.Services.Interfaces;
using SuKien.DTOs;

namespace SuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly IPostLikeService _postLikeService;
        private readonly IEventLikeService _eventLikeService;

        public LikesController(IPostLikeService postLikeService, IEventLikeService eventLikeService)
        {
            _postLikeService = postLikeService;
            _eventLikeService = eventLikeService;
        }

        // Like a Post
        [HttpPost("post/{postId}/like")]
        public async Task<IActionResult> LikePost(int postId, [FromBody] int participantId)
        {
            var result = await _postLikeService.LikePostAsync(postId, participantId);
            if (result == null)
                return BadRequest("Unable to like post.");

            return Ok(result);
        }

        // Unlike a Post
        [HttpDelete("post/like/{postLikeId}")]
        public async Task<IActionResult> UnlikePost(int postLikeId)
        {
            var success = await _postLikeService.UnlikePostAsync(postLikeId);
            if (!success)
                return NotFound("Post like not found or already removed.");

            return NoContent();
        }

        // Get all Likes for a Post
        [HttpGet("post/{postId}/likes")]
        public async Task<ActionResult<IEnumerable<PostLikeDTO>>> GetLikesByPostId(int postId)
        {
            var likes = await _postLikeService.GetLikesByPostIdAsync(postId);
            return Ok(likes);
        }

        // Like an Event
        [HttpPost("event/{eventId}/like")]
        public async Task<IActionResult> LikeEvent(int eventId, [FromBody] int participantId)
        {
            var result = await _eventLikeService.LikeEventAsync(eventId, participantId);
            if (result == null)
                return BadRequest("Unable to like event.");

            return Ok(result);
        }

        // Unlike an Event
        [HttpDelete("event/like/{likeId}")]
        public async Task<IActionResult> UnlikeEvent(int likeId)
        {
            var success = await _eventLikeService.UnlikeEventAsync(likeId);
            if (!success)
                return NotFound("Event like not found or already removed.");

            return NoContent();
        }

        // Get all Likes for an Event
        [HttpGet("event/{eventId}/likes")]
        public async Task<ActionResult<IEnumerable<EventLikeDTO>>> GetLikesByEventId(int eventId)
        {
            var likes = await _eventLikeService.GetLikesByEventIdAsync(eventId);
            return Ok(likes);
        }
    }
}
