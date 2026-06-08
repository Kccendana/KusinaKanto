using Microsoft.EntityFrameworkCore;
using KusinaKanto.Data;
using KusinaKanto.Models;

namespace KusinaKanto.Services;

public class EfStaffService : IStaffService
{
    private readonly KusinaKantoDbContext _db;

    public EfStaffService(KusinaKantoDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<Staff>> GetAllAsync() =>
        await _db.Staff.AsNoTracking().OrderBy(s => s.Name).ToListAsync();

    public async Task CreateAsync(Staff staff)
    {
        if (string.IsNullOrEmpty(staff.Id))
            staff.Id = Guid.NewGuid().ToString("N");
        _db.Staff.Add(staff);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Staff staff)
    {
        _db.Staff.Update(staff);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var existing = await _db.Staff.FindAsync(id);
        if (existing is null) return;
        _db.Staff.Remove(existing);
        await _db.SaveChangesAsync();
    }
}
