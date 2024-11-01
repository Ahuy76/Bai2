using SuKien.DTOs;
using SuKien.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuKien.Models;
using SuKien.Services.Interfaces;

namespace SuKien.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminDTO> GetAdminByIdAsync(int adminId)
        {
            var adminEntity = await _context.Admins.FindAsync(adminId);
            if (adminEntity == null) return null;

            return new AdminDTO
            {
                AdminID = adminEntity.AdminID,
                Username = adminEntity.Username,
                Password = adminEntity.Password,
                Email = adminEntity.Email
            };
        }

        public async Task<IEnumerable<AdminDTO>> GetAllAdminsAsync()
        {
            var admins = await _context.Admins.ToListAsync();
            return admins.Select(a => new AdminDTO
            {
                AdminID = a.AdminID,
                Username = a.Username,
                Password = a.Password,
                Email = a.Email
            });
        }

        public async Task<AdminDTO> CreateAdminAsync(AdminDTO adminDto)
        {
            var adminEntity = new Admin
            {
                Username = adminDto.Username,
                Password = adminDto.Password,
                Email = adminDto.Email
            };

            await _context.Admins.AddAsync(adminEntity);
            await _context.SaveChangesAsync();

            return new AdminDTO
            {
                AdminID = adminEntity.AdminID,
                Username = adminEntity.Username,
                Password = adminEntity.Password,
                Email = adminEntity.Email
            };
        }

        public async Task UpdateAdminAsync(AdminDTO adminDto)
        {
            var adminEntity = await _context.Admins.FindAsync(adminDto.AdminID);
            if (adminEntity == null) return;

            adminEntity.Username = adminDto.Username;
            adminEntity.Password = adminDto.Password;
            adminEntity.Email = adminDto.Email;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAdminAsync(int adminId)
        {
            var adminEntity = await _context.Admins.FindAsync(adminId);
            if (adminEntity != null)
            {
                _context.Admins.Remove(adminEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
