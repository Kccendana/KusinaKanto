namespace KusinaKanto.Models
{
    public class Order
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string CustomerName { get; set; }
    public string TableNumber { get; set; } // null if takeout

    public string Status { get; set; } = "Pending";

    public decimal TotalAmount { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
}