using SuKien.DTOs;

namespace SuKien.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostDTO> GetPostByIdAsync(int postId);
        Task<IEnumerable<PostDTO>> GetAllPostsByEventIdAsync(int eventId);
        Task<PostDTO> CreatePostAsync(PostDTO postDto);
        Task<bool> UpdatePostAsync(PostDTO postDto);
        Task<bool> DeletePostAsync(int postId);
    }
}