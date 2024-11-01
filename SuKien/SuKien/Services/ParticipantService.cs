using SuKien.DTOs;
using SuKien.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuKien.Models;

namespace SuKien.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly ApplicationDbContext _context;

        public ParticipantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ParticipantDTO> GetParticipantByIdAsync(int participantId)
        {
            var participant = await _context.Participants.FindAsync(participantId);
            if (participant == null) return null;

            return new ParticipantDTO
            {
                ParticipantID = participant.ParticipantID,
                Username = participant.Username,  // Sử dụng Username thay vì Name
                Password = participant.Password,    // Thêm Password nếu cần
                Email = participant.Email
            };
        }

        public async Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync()
        {
            var participants = await _context.Participants.ToListAsync();
            return participants.Select(p => new ParticipantDTO
            {
                ParticipantID = p.ParticipantID,
                Username = p.Username,  // Sử dụng Username thay vì Name
                Password = p.Password,   // Thêm Password nếu cần
                Email = p.Email
            });
        }

        public async Task<ParticipantDTO> CreateParticipantAsync(ParticipantDTO participantDto)
        {
            var participantEntity = new Participant
            {
                Username = participantDto.Username,  // Sử dụng Username
                Password = participantDto.Password,  // Thêm Password nếu cần
                Email = participantDto.Email
            };

            await _context.Participants.AddAsync(participantEntity);
            await _context.SaveChangesAsync();

            participantDto.ParticipantID = participantEntity.ParticipantID;  // Gán ID cho DTO
            return participantDto;  // Trả về DTO đã tạo
        }

        public async Task<bool> UpdateParticipantAsync(ParticipantDTO participantDto)
        {
            var participantEntity = await _context.Participants.FindAsync(participantDto.ParticipantID);
            if (participantEntity == null) return false;

            participantEntity.Username = participantDto.Username;  // Cập nhật Username
            participantEntity.Password = participantDto.Password;  // Cập nhật Password nếu cần
            participantEntity.Email = participantDto.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteParticipantAsync(int participantId)
        {
            var participantEntity = await _context.Participants.FindAsync(participantId);
            if (participantEntity == null) return false;

            _context.Participants.Remove(participantEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


