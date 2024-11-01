using SuKien.DTOs;

namespace SuKien.Services
{
    public interface IEventService
    {
        Task<EventDTO> GetEventByIdAsync(int eventId);
        Task<IEnumerable<EventDTO>> GetAllEventsAsync();
        Task<EventDTO> CreateEventAsync(EventDTO eventDto);
        Task<bool> UpdateEventAsync(EventDTO eventDto);
        Task<bool> DeleteEventAsync(int eventId);
    }
}
