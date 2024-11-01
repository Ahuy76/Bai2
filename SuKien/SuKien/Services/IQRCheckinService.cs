using SuKien.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuKien.Services.Interfaces
{
    public interface IQRCheckinService
    {
        Task<QRCheckinDTO> GetCheckinByIdAsync(int checkinId);
        Task<IEnumerable<QRCheckinDTO>> GetCheckinsByEventIdAsync(int eventId);
        Task<IEnumerable<QRCheckinDTO>> GetCheckinsByParticipantIdAsync(int participantId);
        Task<QRCheckinDTO> CreateCheckinAsync(QRCheckinDTO checkinDto);
        Task<bool> DeleteCheckinAsync(int checkinId);
    }
}
