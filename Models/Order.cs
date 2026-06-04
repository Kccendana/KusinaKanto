using System.ComponentModel.DataAnnotations;
namespace KusinaKanto.Models;

public enum OrderStatus
{
    Pending,
    Confirmed,
    Preparing,
    Ready,
    Completed
}

/// <summary>A placed customer order.</summary>
public class Order
{
    [Key]
    public string Id { get; set; } = "";
    public string CustomerName { get; set; } = "";
    public string CustomerEmail { get; set; } = "";
    public string TableNumber { get; set; } = "";
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalAmount { get; set; }
    public string Notes { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public List<OrderItem> Items { get; set; } = new();
}

