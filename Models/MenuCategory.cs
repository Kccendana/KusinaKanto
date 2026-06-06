using System.ComponentModel.DataAnnotations;

namespace KusinaKanto.Models;
/// <summary>A group of menu items, e.g. "Starters" or "Desserts".</summary>
public class MenuCategory
{
    [Key]
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int DisplayOrder { get; set; }
}