using SuKien.DTOs;
using SuKien.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuKien.Models;
using SuKien.Services.Interfaces;

namespace SuKien.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EventDTO> GetEventByIdAsync(int eventId)
        {
            var eventEntity = await _context.Events.FindAsync(eventId);
            if (eventEntity == null) return null;

            return new EventDTO
            {
                EventID = eventEntity.EventID,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                Timeline = eventEntity.Timeline,
                ImageURL = eventEntity.ImageURL,
                CreatedBy = eventEntity.CreatedBy,
                QRCode = eventEntity.QRCode
            };
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventsAsync()
        {
            var events = await _context.Events.ToListAsync();
            return events.Select(e => new EventDTO
            {
                EventID = e.EventID,
                Title = e.Title,
                Description = e.Description,
                Timeline = e.Timeline,
                ImageURL = e.ImageURL,
                CreatedBy = e.CreatedBy,
                QRCode = e.QRCode
            });
        }

        public async Task<EventDTO> CreateEventAsync(EventDTO eventDto)
        {
            var eventEntity = new Event
            {
                Title = eventDto.Title,
                Description = eventDto.Description,
                Timeline = eventDto.Timeline,
                ImageURL = eventDto.ImageURL,
                CreatedBy = eventDto.CreatedBy,
                QRCode = eventDto.QRCode
            };

            await _context.Events.AddAsync(eventEntity);
            await _context.SaveChangesAsync();

            eventDto.EventID = eventEntity.EventID; // Cập nhật EventID cho DTO
            return eventDto;
        }

        public async Task<bool> UpdateEventAsync(EventDTO eventDto)
        {
            var eventEntity = await _context.Events.FindAsync(eventDto.EventID);
            if (eventEntity == null) return false; // Trả về false nếu không tìm thấy

            eventEntity.Title = eventDto.Title;
            eventEntity.Description = eventDto.Description;
            eventEntity.Timeline = eventDto.Timeline;
            eventEntity.ImageURL = eventDto.ImageURL;
            eventEntity.CreatedBy = eventDto.CreatedBy;
            eventEntity.QRCode = eventDto.QRCode;

            await _context.SaveChangesAsync();
            return true; // Trả về true nếu cập nhật thành công
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var eventEntity = await _context.Events.FindAsync(eventId);
            if (eventEntity == null) return false; // Trả về false nếu không tìm thấy

            _context.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();
            return true; // Trả về true nếu xóa thành công
        }
    }
}




