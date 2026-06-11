using System.ComponentModel.DataAnnotations;

namespace KusinaKanto.Models;
/// <summary>A line item within an order (snapshot of the dish at order time).</summary>
public class OrderItem
{
    [Key]
    public int Id { get; set; }
    public string MenuItemId { get; set; } = "";
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
}
