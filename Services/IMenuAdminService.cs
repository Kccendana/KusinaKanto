using KusinaKanto.Models;

namespace KusinaKanto.Services;

/// <summary>Admin-side menu management (full CRUD over menu items).</summary>
public interface IMenuAdminService
{
    Task<IReadOnlyList<MenuItem>> GetItemsAsync();
    Task<IReadOnlyList<MenuCategory>> GetCategoriesAsync();
    Task CreateItemAsync(MenuItem item);
    Task UpdateItemAsync(MenuItem item);
    Task DeleteItemAsync(string id);
}
