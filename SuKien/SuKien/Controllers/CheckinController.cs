using Microsoft.AspNetCore.Mvc;
using SuKien.DTOs;
using SuKien.Services.Interfaces;

namespace SuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckinController : ControllerBase
    {
        private readonly IQRCheckinService _qrCheckinService;

        public CheckinController(IQRCheckinService qrCheckinService)
        {
            _qrCheckinService = qrCheckinService;
        }

        // Get Check-in by ID
        [HttpGet("{checkinId}")]
        public async Task<ActionResult<QRCheckinDTO>> GetCheckinById(int checkinId)
        {
            var checkin = await _qrCheckinService.GetCheckinByIdAsync(checkinId);
            if (checkin == null) return NotFound();

            return Ok(checkin);
        }

        // Get all Check-ins for a specific Event
        [HttpGet("event/{eventId}")]
        public async Task<ActionResult<IEnumerable<QRCheckinDTO>>> GetCheckinsByEventId(int eventId)
        {
            var checkins = await _qrCheckinService.GetCheckinsByEventIdAsync(eventId);
            return Ok(checkins);
        }

        // Get all Check-ins for a specific Participant
        [HttpGet("participant/{participantId}")]
        public async Task<ActionResult<IEnumerable<QRCheckinDTO>>> GetCheckinsByParticipantId(int participantId)
        {
            var checkins = await _qrCheckinService.GetCheckinsByParticipantIdAsync(participantId);
            return Ok(checkins);
        }

        // Create a new Check-in
        [HttpPost]
        public async Task<ActionResult<QRCheckinDTO>> CreateCheckin(QRCheckinDTO checkinDto)
        {
            var createdCheckin = await _qrCheckinService.CreateCheckinAsync(checkinDto);
            return CreatedAtAction(nameof(GetCheckinById), new { checkinId = createdCheckin.CheckinID }, createdCheckin);
        }

        // Delete a Check-in
        [HttpDelete("{checkinId}")]
        public async Task<IActionResult> DeleteCheckin(int checkinId)
        {
            var success = await _qrCheckinService.DeleteCheckinAsync(checkinId);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}

