using Microsoft.AspNetCore.Mvc;
using SuKien.DTOs;
using SuKien.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDTO>> GetEventByIdAsync(int id)
        {
            var eventDto = await _eventService.GetEventByIdAsync(id);
            if (eventDto == null) return NotFound();
            return Ok(eventDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetAllEventsAsync()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpPost]
        public async Task<ActionResult<EventDTO>> CreateEventAsync([FromBody] EventDTO eventDto)
        {
            await _eventService.CreateEventAsync(eventDto);
            return CreatedAtAction(nameof(GetEventByIdAsync), new { id = eventDto.EventID }, eventDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEventAsync([FromBody] EventDTO eventDto)
        {
            var result = await _eventService.UpdateEventAsync(eventDto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventAsync(int id)
        {
            var result = await _eventService.DeleteEventAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}

