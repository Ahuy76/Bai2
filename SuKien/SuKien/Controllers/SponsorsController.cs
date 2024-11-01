using Microsoft.AspNetCore.Mvc;
using SuKien.DTOs;
using SuKien.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly ISponsorService _sponsorService;

        public SponsorController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SponsorDTO>> GetSponsorByIdAsync(int id)
        {
            var sponsorDto = await _sponsorService.GetSponsorByIdAsync(id);
            if (sponsorDto == null) return NotFound();
            return Ok(sponsorDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SponsorDTO>>> GetAllSponsorsAsync()
        {
            var sponsors = await _sponsorService.GetAllSponsorsAsync();
            return Ok(sponsors);
        }

        [HttpPost]
        public async Task<ActionResult<SponsorDTO>> CreateSponsorAsync([FromBody] SponsorDTO sponsorDto)
        {
            await _sponsorService.CreateSponsorAsync(sponsorDto);
            return CreatedAtAction(nameof(GetSponsorByIdAsync), new { id = sponsorDto.SponsorID }, sponsorDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSponsorAsync([FromBody] SponsorDTO sponsorDto)
        {
            var result = await _sponsorService.UpdateSponsorAsync(sponsorDto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSponsorAsync(int id)
        {
            var result = await _sponsorService.DeleteSponsorAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
