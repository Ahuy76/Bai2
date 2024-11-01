using SuKien.DTOs;
using SuKien.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuKien.Models;

namespace SuKien.Services
{
    public class SponsorService : ISponsorService
    {
        private readonly ApplicationDbContext _context;

        public SponsorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SponsorDTO> GetSponsorByIdAsync(int sponsorId)
        {
            var sponsorEntity = await _context.Sponsors.FindAsync(sponsorId);
            if (sponsorEntity == null) return null;

            return new SponsorDTO
            {
                SponsorID = sponsorEntity.SponsorID,
                Name = sponsorEntity.Name,
                Description = sponsorEntity.Description,
                LogoURL = sponsorEntity.LogoURL
            };
        }

        public async Task<IEnumerable<SponsorDTO>> GetAllSponsorsAsync()
        {
            var sponsors = await _context.Sponsors.ToListAsync();
            return sponsors.Select(s => new SponsorDTO
            {
                SponsorID = s.SponsorID,
                Name = s.Name,
                Description = s.Description,
                LogoURL = s.LogoURL
            });
        }

        public async Task<SponsorDTO> CreateSponsorAsync(SponsorDTO sponsorDto)
        {
            var sponsorEntity = new Sponsor
            {
                Name = sponsorDto.Name,
                Description = sponsorDto.Description,
                LogoURL = sponsorDto.LogoURL
            };

            await _context.Sponsors.AddAsync(sponsorEntity);
            await _context.SaveChangesAsync();

            sponsorDto.SponsorID = sponsorEntity.SponsorID; // Set ID after saving
            return sponsorDto;
        }

        public async Task<bool> UpdateSponsorAsync(SponsorDTO sponsorDto)
        {
            var sponsorEntity = await _context.Sponsors.FindAsync(sponsorDto.SponsorID);
            if (sponsorEntity == null) return false;

            sponsorEntity.Name = sponsorDto.Name;
            sponsorEntity.Description = sponsorDto.Description;
            sponsorEntity.LogoURL = sponsorDto.LogoURL;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSponsorAsync(int sponsorId)
        {
            var sponsorEntity = await _context.Sponsors.FindAsync(sponsorId);
            if (sponsorEntity == null) return false;

            _context.Sponsors.Remove(sponsorEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

