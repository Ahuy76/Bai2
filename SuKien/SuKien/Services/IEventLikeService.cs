using SuKien.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuKien.Services.Interfaces
{
    public interface IEventLikeService
    {
        // Method to like an event
        Task<EventLikeDTO> LikeEventAsync(int eventId, int participantId);

        // Method to unlike an event
        Task<bool> UnlikeEventAsync(int likeId);

        // Method to get all likes for a specific event by event ID
        Task<IEnumerable<EventLikeDTO>> GetLikesByEventIdAsync(int eventId);
    }
}
