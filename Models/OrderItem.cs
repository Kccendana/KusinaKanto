namespace KusinaKanto.Models
{
    public class OrderItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string OrderId { get; set; }
    public string MenuItemId { get; set; }

    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
}
}