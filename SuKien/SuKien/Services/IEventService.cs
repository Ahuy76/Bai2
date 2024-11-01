using SuKien.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuKien.Services.Interfaces
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






