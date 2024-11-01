using SuKien.Data;
using SuKien.DTOs;
using SuKien.Models;
using SuKien.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuKien.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostDTO> GetPostByIdAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null) return null;

            return new PostDTO
            {
                PostID = post.PostID,
                EventID = post.EventID,
                Content = post.Content,
                CreatedAt = post.CreatedAt
            };
        }

        public async Task<IEnumerable<PostDTO>> GetAllPostsByEventIdAsync(int eventId)
        {
            var posts = await _context.Posts
                .Where(p => p.EventID == eventId)
                .ToListAsync();

            return posts.Select(p => new PostDTO
            {
                PostID = p.PostID,
                EventID = p.EventID,
                Content = p.Content,
                CreatedAt = p.CreatedAt
            });
        }

        public async Task<PostDTO> CreatePostAsync(PostDTO postDto)
        {
            var post = new Post
            {
                EventID = postDto.EventID,
                Content = postDto.Content,
                CreatedAt = postDto.CreatedAt ?? DateTime.Now // Use current time if CreatedAt is null
            };

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            postDto.PostID = post.PostID;
            return postDto;
        }

        public async Task<bool> UpdatePostAsync(PostDTO postDto)
        {
            var post = await _context.Posts.FindAsync(postDto.PostID);
            if (post == null) return false;

            post.Content = postDto.Content;
            post.CreatedAt = postDto.CreatedAt ?? post.CreatedAt; // Retain existing CreatedAt if null

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeletePostAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null) return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
