using Microsoft.AspNetCore.Mvc;
using SuKien.DTOs;
using SuKien.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDTO>> GetAdminByIdAsync(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            if (admin == null) return NotFound();
            return Ok(admin);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDTO>>> GetAllAdminsAsync()
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return Ok(admins);
        }

        [HttpPost]
        public async Task<ActionResult<AdminDTO>> CreateAdminAsync([FromBody] AdminDTO adminDto)
        {
            var createdAdmin = await _adminService.CreateAdminAsync(adminDto);
            return CreatedAtAction(nameof(GetAdminByIdAsync), new { id = createdAdmin.AdminID }, createdAdmin);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdminAsync([FromBody] AdminDTO adminDto)
        {
            await _adminService.UpdateAdminAsync(adminDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminAsync(int id)
        {
            var result = await _adminService.DeleteAdminAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}

