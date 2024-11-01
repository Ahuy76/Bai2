using Microsoft.AspNetCore.Mvc;
using SuKien.DTOs;
using SuKien.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantDTO>> GetParticipantByIdAsync(int id)
        {
            var participantDto = await _participantService.GetParticipantByIdAsync(id);
            if (participantDto == null) return NotFound();
            return Ok(participantDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantDTO>>> GetAllParticipantsAsync()
        {
            var participants = await _participantService.GetAllParticipantsAsync();
            return Ok(participants);
        }

        [HttpPost]
        public async Task<ActionResult<ParticipantDTO>> CreateParticipantAsync([FromBody] ParticipantDTO participantDto)
        {
            var createdParticipant = await _participantService.CreateParticipantAsync(participantDto);
            return CreatedAtAction(nameof(GetParticipantByIdAsync), new { id = createdParticipant.ParticipantID }, createdParticipant);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateParticipantAsync([FromBody] ParticipantDTO participantDto)
        {
            var result = await _participantService.UpdateParticipantAsync(participantDto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantAsync(int id)
        {
            var result = await _participantService.DeleteParticipantAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}

