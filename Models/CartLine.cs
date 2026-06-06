namespace KusinaKanto.Models;
/// <summary>A menu item plus the quantity the customer has added to their cart.</summary>
public class CartLine
{
    public MenuItem Item { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal Subtotal => Item.Price * Quantity;
}