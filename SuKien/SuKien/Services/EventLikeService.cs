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
    public class EventLikeService : IEventLikeService
    {
        private readonly ApplicationDbContext _context;

        public EventLikeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EventLikeDTO> LikeEventAsync(int eventId, int participantId)
        {
            var eventLike = new EventLike
            {
                EventID = eventId,
                ParticipantID = participantId
            };

            await _context.EventLikes.AddAsync(eventLike);
            await _context.SaveChangesAsync();

            return new EventLikeDTO
            {
                LikeID = eventLike.LikeID,
                EventID = eventLike.EventID,
                ParticipantID = eventLike.ParticipantID
            };
        }

        public async Task<bool> UnlikeEventAsync(int likeId)
        {
            var eventLike = await _context.EventLikes.FindAsync(likeId);
            if (eventLike == null) return false;

            _context.EventLikes.Remove(eventLike);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EventLikeDTO>> GetLikesByEventIdAsync(int eventId)
        {
            return await _context.EventLikes
                .Where(el => el.EventID == eventId)
                .Select(el => new EventLikeDTO
                {
                    LikeID = el.LikeID,
                    EventID = el.EventID,
                    ParticipantID = el.ParticipantID
                })
                .ToListAsync();
        }
    }
}
