using KusinaKanto.Models;

namespace KusinaKanto.Services;

/// <summary>
/// Supplies menu data to the UI. The UI is written against this interface only,
/// so the backend (Katherine's EF Core + SQL Server data layer) can replace
/// <see cref="InMemoryMenuService"/> without any UI changes.
/// </summary>
public interface IMenuService
{
    Task<IReadOnlyList<MenuCategory>> GetCategoriesAsync();
    Task<IReadOnlyList<MenuItem>> GetAvailableItemsAsync();
}
