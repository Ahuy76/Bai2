using SuKien.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuKien.Services.Interfaces
{
    public interface IAdminService
    {
        Task<AdminDTO> GetAdminByIdAsync(int adminId);
        Task<IEnumerable<AdminDTO>> GetAllAdminsAsync();
        Task<AdminDTO> CreateAdminAsync(AdminDTO adminDto);
        Task UpdateAdminAsync(AdminDTO adminDto);
        Task<bool> DeleteAdminAsync(int adminId); // Đảm bảo phương thức này trả về Task<bool>
    }
}



