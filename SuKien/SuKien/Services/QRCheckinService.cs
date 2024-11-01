using SuKien.Data;
using SuKien.DTOs;
using SuKien.Models;
using SuKien.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuKien.Services
{
    public class QRCheckinService : IQRCheckinService
    {
        private readonly ApplicationDbContext _context;

        public QRCheckinService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<QRCheckinDTO> GetCheckinByIdAsync(int checkinId)
        {
            var checkin = await _context.QRCheckins.FindAsync(checkinId);
            if (checkin == null) return null;

            return new QRCheckinDTO
            {
                CheckinID = checkin.CheckinID,
                ParticipantID = checkin.ParticipantID,
                EventID = checkin.EventID,
                CheckinTime = checkin.CheckinTime
            };
        }

        public async Task<IEnumerable<QRCheckinDTO>> GetCheckinsByEventIdAsync(int eventId)
        {
            var checkins = await _context.QRCheckins
                .Where(c => c.EventID == eventId)
                .ToListAsync();

            return checkins.Select(c => new QRCheckinDTO
            {
                CheckinID = c.CheckinID,
                ParticipantID = c.ParticipantID,
                EventID = c.EventID,
                CheckinTime = c.CheckinTime
            });
        }

        public async Task<IEnumerable<QRCheckinDTO>> GetCheckinsByParticipantIdAsync(int participantId)
        {
            var checkins = await _context.QRCheckins
                .Where(c => c.ParticipantID == participantId)
                .ToListAsync();

            return checkins.Select(c => new QRCheckinDTO
            {
                CheckinID = c.CheckinID,
                ParticipantID = c.ParticipantID,
                EventID = c.EventID,
                CheckinTime = c.CheckinTime
            });
        }

        public async Task<QRCheckinDTO> CreateCheckinAsync(QRCheckinDTO checkinDto)
        {
            var checkin = new QRCheckin
            {
                ParticipantID = checkinDto.ParticipantID,
                EventID = checkinDto.EventID,
                CheckinTime = DateTime.Now // Automatically set check-in time
            };

            await _context.QRCheckins.AddAsync(checkin);
            await _context.SaveChangesAsync();

            checkinDto.CheckinID = checkin.CheckinID;
            checkinDto.CheckinTime = checkin.CheckinTime;
            return checkinDto;
        }

        public async Task<bool> DeleteCheckinAsync(int checkinId)
        {
            var checkin = await _context.QRCheckins.FindAsync(checkinId);
            if (checkin == null) return false;

            _context.QRCheckins.Remove(checkin);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

