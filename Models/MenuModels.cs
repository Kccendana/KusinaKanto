namespace KusinaKanto.Models;

/// <summary>A group of menu items, e.g. "Starters" or "Desserts".</summary>
public class MenuCategory
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int DisplayOrder { get; set; }
}

/// <summary>A single dish on the menu.</summary>
public class MenuItem
{
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

/// <summary>A menu item plus the quantity the customer has added to their cart.</summary>
public class CartLine
{
    public MenuItem Item { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal Subtotal => Item.Price * Quantity;
}
