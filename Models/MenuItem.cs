using System.ComponentModel.DataAnnotations;

namespace KusinaKanto.Models;

/// <summary>A single dish on the menu.</summary>
public class MenuItem
{
    [Key]
    public string Id { get; set; } = "";
    public string CategoryId { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = "";
    public bool IsAvailable { get; set; } = true;
    public bool IsBestseller { get; set; }
    public bool IsSpicy { get; set; }
}


