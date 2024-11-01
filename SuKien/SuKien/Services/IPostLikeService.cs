using SuKien.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuKien.Services.Interfaces
{
    public interface IPostLikeService
    {
        Task<PostLikeDTO> LikePostAsync(int postId, int participantId);
        Task<bool> UnlikePostAsync(int postLikeId);
        Task<IEnumerable<PostLikeDTO>> GetLikesByPostIdAsync(int postId);
    }
}

