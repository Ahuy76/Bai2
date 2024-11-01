using SuKien.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuKien.Services
{
    public interface IParticipantService
    {
        Task<ParticipantDTO> GetParticipantByIdAsync(int participantId);
        Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync();
        Task<ParticipantDTO> CreateParticipantAsync(ParticipantDTO participantDto);
        Task<bool> UpdateParticipantAsync(ParticipantDTO participantDto);
        Task<bool> DeleteParticipantAsync(int participantId);
    }
}


