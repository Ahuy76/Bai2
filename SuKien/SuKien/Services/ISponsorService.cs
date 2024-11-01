using SuKien.DTOs;

namespace SuKien.Services
{
    public interface ISponsorService
    {
        Task<SponsorDTO> GetSponsorByIdAsync(int sponsorId);
        Task<IEnumerable<SponsorDTO>> GetAllSponsorsAsync();
        Task<SponsorDTO> CreateSponsorAsync(SponsorDTO sponsorDto);
        Task<bool> UpdateSponsorAsync(SponsorDTO sponsorDto);
        Task<bool> DeleteSponsorAsync(int sponsorId);
    }
}
