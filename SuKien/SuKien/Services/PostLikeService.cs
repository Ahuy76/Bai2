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
    public class PostLikeService : IPostLikeService
    {
        private readonly ApplicationDbContext _context;

        public PostLikeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostLikeDTO> LikePostAsync(int postId, int participantId)
        {
            var postLike = new PostLike
            {
                PostID = postId,
                ParticipantID = participantId,
                LikedAt = DateTime.Now
            };

            await _context.PostLikes.AddAsync(postLike);
            await _context.SaveChangesAsync();

            return new PostLikeDTO
            {
                PostLikeID = postLike.PostLikeID,
                PostID = postLike.PostID,
                ParticipantID = postLike.ParticipantID,
                LikedAt = postLike.LikedAt
            };
        }

        public async Task<bool> UnlikePostAsync(int postLikeId)
        {
            var postLike = await _context.PostLikes.FindAsync(postLikeId);
            if (postLike == null) return false;

            _context.PostLikes.Remove(postLike);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PostLikeDTO>> GetLikesByPostIdAsync(int postId)
        {
            return await _context.PostLikes
                .Where(pl => pl.PostID == postId)
                .Select(pl => new PostLikeDTO
                {
                    PostLikeID = pl.PostLikeID,
                    PostID = pl.PostID,
                    ParticipantID = pl.ParticipantID,
                    LikedAt = pl.LikedAt
                })
                .ToListAsync();
        }
    }
}

