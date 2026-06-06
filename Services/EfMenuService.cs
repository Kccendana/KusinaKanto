using Microsoft.EntityFrameworkCore;
using KusinaKanto.Data;
using KusinaKanto.Models;

namespace KusinaKanto.Services;

public class EfMenuService : IMenuService
{
    private readonly KusinaKantoDbContext _db;

    public EfMenuService(KusinaKantoDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<MenuCategory>> GetCategoriesAsync()
    {
        return await _db.MenuCategories
            .OrderBy(c => c.DisplayOrder)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<MenuItem>> GetAvailableItemsAsync()
    {
        return await _db.MenuItems
            .Where(i => i.IsAvailable)
            .ToListAsync();
    }
}