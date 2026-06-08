using Microsoft.EntityFrameworkCore;
using KusinaKanto.Data;
using KusinaKanto.Models;

namespace KusinaKanto.Services;

public class EfMenuAdminService : IMenuAdminService
{
    private readonly KusinaKantoDbContext _db;

    public EfMenuAdminService(KusinaKantoDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<MenuItem>> GetItemsAsync() =>
        await _db.MenuItems.AsNoTracking().OrderBy(i => i.CategoryId).ThenBy(i => i.Name).ToListAsync();

    public async Task<IReadOnlyList<MenuCategory>> GetCategoriesAsync() =>
        await _db.MenuCategories.AsNoTracking().OrderBy(c => c.DisplayOrder).ToListAsync();

    public async Task CreateItemAsync(MenuItem item)
    {
        if (string.IsNullOrEmpty(item.Id))
            item.Id = Guid.NewGuid().ToString("N");
        _db.MenuItems.Add(item);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateItemAsync(MenuItem item)
    {
        _db.MenuItems.Update(item);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(string id)
    {
        var existing = await _db.MenuItems.FindAsync(id);
        if (existing is null) return;
        _db.MenuItems.Remove(existing);
        await _db.SaveChangesAsync();
    }
}
