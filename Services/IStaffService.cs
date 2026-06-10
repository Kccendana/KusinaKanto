using KusinaKanto.Models;

namespace KusinaKanto.Services;

/// <summary>Full CRUD over staff members.</summary>
public interface IStaffService
{
    Task<IReadOnlyList<Staff>> GetAllAsync();
    Task<Staff?> GetByEmailAsync(string email);
    Task CreateAsync(Staff staff);
    Task UpdateAsync(Staff staff);
    Task DeleteAsync(string id);
}
