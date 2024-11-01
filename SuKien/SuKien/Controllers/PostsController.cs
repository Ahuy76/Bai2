using Microsoft.AspNetCore.Mvc;
using SuKien.DTOs;
using SuKien.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet("{postId}")]
    public async Task<ActionResult<PostDTO>> GetPostById(int postId)
    {
        var post = await _postService.GetPostByIdAsync(postId);
        if (post == null) return NotFound();
        return Ok(post);
    }

    [HttpGet("event/{eventId}")]
    public async Task<ActionResult<IEnumerable<PostDTO>>> GetPostsByEventId(int eventId)
    {
        var posts = await _postService.GetAllPostsByEventIdAsync(eventId);
        return Ok(posts);
    }

    [HttpPost]
    public async Task<ActionResult<PostDTO>> CreatePost(PostDTO postDto)
    {
        var createdPost = await _postService.CreatePostAsync(postDto);
        return CreatedAtAction(nameof(GetPostById), new { postId = createdPost.PostID }, createdPost);
    }

    [HttpPut("{postId}")]
    public async Task<IActionResult> UpdatePost(int postId, PostDTO postDto)
    {
        postDto.PostID = postId;
        var result = await _postService.UpdatePostAsync(postDto);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("{postId}")]
    public async Task<IActionResult> DeletePost(int postId)
    {
        var result = await _postService.DeletePostAsync(postId);
        if (!result) return NotFound();
        return NoContent();
    }
}

